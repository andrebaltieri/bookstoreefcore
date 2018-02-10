using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;

namespace BookStore.ViewModels.BookViewModels
{
    public class EditorBookViewModel : Notifiable, IValidatable
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Title, 120, "Title", "Título deve conter até 120 caracteres")
                    .HasMinLen(Title, 3, "Title", "Título deve conter pelo menos 3 caracteres")
                    .HasLen(ISBN, 17, "ISBN", "O ISBN deve conter 17 caracteres")
                    .IsGreaterOrEqualsThan(ReleaseDate, DateTime.Now.Date, "ReleaseData", "Data de lançamento inválida")
            );
        }
    }
}