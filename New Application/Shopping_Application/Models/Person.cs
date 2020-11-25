
// Model for the data about users

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shopping_Application.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "Vorname")]                                 // Validierungsattribut um Vaildierungsregeln festzulegen, die bei den Daten die in das Formular eingegeben wurden gelten sollen
        [Required(ErrorMessage = "Bitte gib deinen Vornamen ein.")]
        public string FirstName { get; set; }

        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Bitte gib deinen Nachnamen ein.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Addresse")]
        [Required(ErrorMessage = "Bitte gib deine Email Addresse ein.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Bestätige Email Addresse")]
        [Compare("EmailAddress", ErrorMessage = "Die Email Addresse und die Bestätigungs Email Addresse müssen übereinstimmen.")]
        public string ConfirmEmail { get; set; }

        [Display(Name ="Passwort")]
        [Required(ErrorMessage ="Bitte gib ein Passwort ein.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "Bitte gib ein Passwort mit mindestens 7 Zeichen ein.")]
        public string Password { get; set; }

        [Display(Name ="Bestätige Passwort")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Dein Passwort und dein Bestätigungspasswort müssen übereinstimmen.")]
        public string ConfirmPassword { get; set; }

    }
}