using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using InterviewTest1.Models;

namespace InterviewTest1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //*********************************************************
            //Exercise 1
            //Author    :IYAMPERUMAL(PERU) RATHINAM
            //Date      :19-June-2014
            //*********************************************************
            Console.WriteLine("Exercise 1 - IYAMPERUMAL(PERU) RATHINAM");
            var data = new Repo().All();

            foreach (Invoice invoice in data.ToList())
            {
                foreach (InvoiceItem invoiceItem in invoice.LineItems)
                {
                    invoiceItem.Total = invoiceItem.Total + (invoiceItem.Taxable ? invoiceItem.Total * invoice.TaxRate : 0);
                    invoice.SubTotal += invoiceItem.Total;
                }
            }

            data.SelectMany(invoice => invoice.LineItems)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.ReadLine();

            //*********************************************************
            //Exercise 2
            //Author    :IYAMPERUMAL(PERU) RATHINAM
            //Date      :19-June-2014
            //*********************************************************
            Console.WriteLine("Exercise 2 - IYAMPERUMAL(PERU) RATHINAM");

            //Invoice Information
            foreach (Invoice invoice in data.ToList())
            {
                invoice.SubTotal = invoice.LineItems.Sum(d => d.Total);
                invoice.Total=invoice.SubTotal + invoice.Shipping;
                Console.WriteLine(string.Format("Invoice Number:{0}\t Company Name:{1}\t SubTotal:{2:#,0.00}\t Total:{3:#,0.00}",
                    invoice.InvoiceNo,
                    invoice.CompanyName,
                    invoice.SubTotal,
                    invoice.Total));

                //Invoice Item information
                invoice.LineItems.ToList().ForEach(Console.WriteLine);
            }

            Console.ReadLine();

            //*********************************************************
            //Exercise 3
            //Author    :IYAMPERUMAL(PERU) RATHINAM
            //Date      :19-June-2014
            //*********************************************************
            Console.WriteLine("Exercise 3 - IYAMPERUMAL(PERU) RATHINAM");

            //Invoice Information
            foreach (Invoice invoice in data.ToList())
            {
                invoice.SubTotal = invoice.LineItems.Sum(d => d.Total);
                invoice.StoreCommissionAmt = Math.Round(invoice.SubTotal * (decimal)0.03, MidpointRounding.AwayFromZero);
                invoice.Total = invoice.SubTotal + invoice.Shipping;
                
                Console.WriteLine(string.Format("Invoice Number:{0}\t Company Name:{1}\t SubTotal:{2:#,0.00}\t Store Commission Amount:{3:#,0.00}\t Total:{4:#,0.00}",
                    invoice.InvoiceNo,
                    invoice.CompanyName,
                    invoice.SubTotal,
                    invoice.StoreCommissionAmt,
                    invoice.LineItems.Sum(d => d.Total) + invoice.Shipping));

                //Invoice Item information
                invoice.LineItems.ToList().ForEach(Console.WriteLine);
            }

            Console.ReadLine();
        }
    }
}
