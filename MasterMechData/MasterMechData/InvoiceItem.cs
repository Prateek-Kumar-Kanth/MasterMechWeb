using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMechData
{
    public class InvoiceItem
    {
        [DisplayName("Invoice Item Serial Number")]
        public int InvoiceItemSNo { get; set; }

        [DisplayName("Invoice Serial Number")]
        public int? InvoiceSNo { get; set; }

        [DisplayName("Item Number")]
        public int? ItemNo { get; set; }

        [DisplayName("Item Description")]
        public string ItemDesc { get; set; }

        [DisplayName("Item Type")]
        public string ItemType { get; set; }

        [DisplayName("Item Category")]
        public string ItemCatg { get; set; }

        [DisplayName("Item Price")]
        public double? ItemPrice { get; set; }

        [DisplayName("Item Unit of Measure")]
        public string ItemUOM { get; set; }

        [DisplayName("Item Status")]
        public string ItemSts { get; set; }

        [DisplayName("CGST Rate")]
        public double? CGSTRate { get; set; }

        [DisplayName("SGST Rate")]
        public double? SGSTRate { get; set; }

        [DisplayName("IGST Rate")]
        public double? IGSTRate { get; set; }

        [DisplayName("UPC Code")]
        public string UPCCode { get; set; }

        [DisplayName("HSN Code")]
        public string HSNCode { get; set; }

        [DisplayName("SAC Code")]
        public string SACCode { get; set; }

        [DisplayName("Quantity")]
        public double? Qty { get; set; }

        [DisplayName("SGST Amount")]
        public double? SGSTAmount { get; set; }

        [DisplayName("CGST Amount")]
        public double? CGSTAmount { get; set; }

        [DisplayName("IGST Amount")]
        public double? IGSTAmount { get; set; }

        [DisplayName("Discount Amount")]
        public double? DiscountAmount { get; set; }

        [DisplayName("Gross Amount")]
        public double? GrossAmount { get; set; }

        [DisplayName("Total Tax")]
        public double? TotalTax { get; set; }

        [DisplayName("Net Amount")]
        public double? NetAmt { get; set; }

        [DisplayName("Total Amount")]
        public double? TotalAmount { get; set; }

        [DisplayName("Created Date")]
        public DateTime Created { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DisplayName("Last Modified Date")]
        public DateTime? Modified { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }

        [DisplayName("Deleted")]
        public char Deleted { get; set; }

        [DisplayName("Deleted On")]
        public DateTime? DeletedOn { get; set; }

        [DisplayName("Deleted By")]
        public string DeletedBy { get; set; }
    }

}
