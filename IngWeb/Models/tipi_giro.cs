//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipi_giro
    {
        public int id { get; set; }
        public string descrizione { get; set; }
        public Nullable<System.TimeSpan> ora_inizio_fascia { get; set; }
        public Nullable<System.TimeSpan> ora_fine_fascia { get; set; }
        public string stato { get; set; }
    }
}