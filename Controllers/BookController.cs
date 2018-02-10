using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModels;
using BookStore.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/books")]
        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList();
        }

        [HttpGet]
        [Route("v1/books/{id}")]
        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        [HttpPost]
        [Route("v1/books")]
        public ResultViewModel Post([FromBody]EditorBookViewModel model)
        {
            // Valida o modelo
            model.Validate();

            // Caso o modelo seja inválido, retorna um erro
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível criar este livro",
                    Data = model.Notifications
                };

            // Gera o modelo
            var book = new Book
            {
                Title = model.Title,
                ISBN = model.ISBN,
                ReleaseDate = model.ReleaseDate
            };

            // Salva as informações
            _context.Books.Add(book);
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Livro cadastrado com sucesso",
                Data = book
            };
        }

        [HttpPut]
        [Route("v1/books/{id}")]
        public ResultViewModel Put([FromBody]EditorBookViewModel model, int id)
        {
            // Valida o modelo
            model.Validate();

            // Caso o modelo seja inválido, retorna um erro
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar este livro",
                    Data = model.Notifications
                };

            // Gera o modelo
            var book = _context.Books.Find(id);
            book.ISBN = model.ISBN;
            book.Title = model.Title;
            book.ReleaseDate = model.ReleaseDate;

            // Salva as informações
            _context.Entry<Book>(book).State = EntityState.Modified;
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Livro alterado com sucesso",
                Data = book
            };
        }

        [HttpDelete]
        [Route("v1/books/{id}")]
        public ResultViewModel Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Livro removido com sucesso",
                Data = null
            };
        }
    }
}