using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootApp.Pages
{
    public class ModelStateFaultModel : PageModel
    {
        private int _chosenTransactionType;
        private string _myTextInputField;

        public void OnGet()
        { 
            bindTransactionTypes();

           // ChosenTransactionType = 1;
            TransactionType = 1;
            MyTextInputField = "TextInputField vanuit de GET";
        }

        private void bindTransactionTypes()
        {
            TransactionTypes = new List<SelectListItem>()
            {
                new SelectListItem("tt1", "1"),
                new SelectListItem("tt2", "2"),
                new SelectListItem("tt3", "3")
            };
        }

        public void OnPost()
        {
            bindTransactionTypes();

            // verwarrend, wat hij dus wel doet is bij posten TransactionType updaten
            // en dan vervolgens bij renderen word dat ook gebruikt om het actieve item te selecteren

            if (_chosenTransactionType != TransactionType)
            {
                Debug.WriteLine("ze zijn niet gelijk");
            }

            _chosenTransactionType = TransactionType;

            // Maar waaom word wat ik hier doe niet gerendered in de page, en dus meegenomen

            // dit moet er gebeuren.. he/huh
            // https://stackoverflow.com/questions/9402575/hidden-fields-dont-get-updated-after-html-form-post-back
            // To solve this, you can call ModelState.Clear() in the post action before you return your view, this way the info in the ModelState is going to be cleared and repopulated once your view is regenerated.
            // ModelState.Clear();
            // ModelState.SetModelValue("ChosenTransactionType", (object?)187, "187");

            _myTextInputField = DateTime.Now.TimeOfDay.Milliseconds.ToString();

          //  this.ModelState.Clear();
         //   var modelStateDictionary = this.ModelState;
        }

        // [BindProperty]
        // public int ChosenTransactionType
        // {
        //     get => _chosenTransactionType;
        //     set => _chosenTransactionType = value;
        // }

        [BindProperty]
        public int TransactionType { get; set; }
        
        public List<SelectListItem> TransactionTypes { get; set; }

        // zonder de bind property word er niet ge-update bij posen
        [BindProperty]
        public string MyTextInputField
        {
            get => _myTextInputField;
            set => _myTextInputField = value;
        }
    }
    
}
