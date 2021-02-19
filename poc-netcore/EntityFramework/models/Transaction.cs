using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Transaction
    {
        public Transaction()
        {
            InverseParenttransaction = new HashSet<Transaction>();
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public int Projectid { get; set; }
        public string Titel { get; set; }
        public int Volgnummer { get; set; }
        public int Transactiontypeid { get; set; }
        public int? Parenttransactionid { get; set; }
        public int Volgnummersub { get; set; }
        public bool Verborgen { get; set; }
        public int Gereed { get; set; }
        public string Soapid { get; set; }
        public bool Agenderen { get; set; }
        public string Initiatingmessnr { get; set; }
        public bool Alleberichtengelezen { get; set; }
        public DateTime Laatstedatumverzonden { get; set; }
        public DateTime Laatstereactietermijn { get; set; }
        public int? Lastmessageid { get; set; }
        public int Initiatorpersoonrolid { get; set; }
        public int Executorpersoonrolid { get; set; }
        public int Volgnummer13 { get; set; }
        public string Volgnummerafk { get; set; }
        public bool? Showinlinkedlist { get; set; }
        public bool? Showassubtransaction { get; set; }
        public bool Reactietermijnverlopenmailsent { get; set; }
        public int Laatsteverzenderpersoonrolid { get; set; }
        public int Laatsteontvangerpersoonrolid { get; set; }
        public decimal Coordx { get; set; }
        public decimal Coordy { get; set; }
        public string Status { get; set; }
        public int? Statusid { get; set; }
        public Guid? Sendservicemessageid { get; set; }
        public int? Messagesendstatus { get; set; }
        public bool? Messageconfirmationreceived { get; set; }
        public string Messagesenderror { get; set; }
        public DateTime? Nextsenddate { get; set; }
        public string Sentmessageconfirmationerror { get; set; }
        public bool Isdeleted { get; set; }

        public virtual Persoonrollen Executorpersoonrol { get; set; }
        public virtual Persoonrollen Initiatorpersoonrol { get; set; }
        public virtual Persoonrollen Laatsteontvangerpersoonrol { get; set; }
        public virtual Persoonrollen Laatsteverzenderpersoonrol { get; set; }
        public virtual Message Lastmessage { get; set; }
        public virtual Transaction Parenttransaction { get; set; }
        public virtual Project Project { get; set; }
        public virtual Transactiontype Transactiontype { get; set; }
        public virtual ICollection<Transaction> InverseParenttransaction { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
