using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NReco.PdfGenerator;
//using IronPdf;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace GeneratePdfFromHtml
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var render = new IronPdf.HtmlToPdf();
            string html = File.ReadAllText(@"~/../../../HtmlSource/ShippingCost.html");
            string detail = File.ReadAllText(@"~/../../../HtmlSource/ShippingFeeDetail.html");
            string organizationInfo = File.ReadAllText(@"~/../../../HtmlSource/organizationInfo.html");
            string inventoryDate = File.ReadAllText(@"~/../../../HtmlSource/inventoryDate.html");
            string total = File.ReadAllText(@"~/../../../HtmlSource/Total.html");
            string css = File.ReadAllText(@"~/../../../HtmlSource/pdf.css");

            html = html.Replace("{sh_id}", "999999");
            html = html.Replace("{yyyy}", DateTime.Now.Year.ToString());
            html = html.Replace("{usr_name}", "HongTT");
            html = html.Replace("{mm}", DateTime.Now.Month.ToString());
            html = html.Replace("{block_code}", "A-00-000");
            html = html.Replace("{block_name}", "Kho Xuat 1");
            html = html.Replace("{created_time}", DateTime.Now.ToString("yyyy/dd/MM hh:mm:ss"));
            html = html.Replace("{page_num}", "1");
            html = html.Replace("{prodiver_cd}", "Pd-0000");
            html = html.Replace("{provider_name}", "Nha cung cap 1");

            html = html.Replace("{contract_type_name}", "Hợp đồng loại 1");
            html = html.Replace("{transaction_type_name}", "Hợp đồng xe");
            string tempDetail = string.Empty;
            //Shipping detail
            for(int i = 0; i < 10; i++)
            {
                string temp = detail;
                temp = temp.Replace("{inventory_date}", DateTime.Now.ToString("yyyy/dd/MM"));
                temp = temp.Replace("{delivery_date}", string.Empty);
                temp = temp.Replace("{wh_block_cd}", "blc_001");
                temp = temp.Replace("{wh_block_name}", "Kho hàng miền bắc");
                temp = temp.Replace("{jis_cd}", "JIS 001");
                temp = temp.Replace("{address}", "13F-Keangnam landmark Phạm Hùng");
                temp = temp.Replace("{wh_cd}", "WH_0001");
                temp = temp.Replace("{wh_name}", "Kho hàng miền bắc");
                temp = temp.Replace("{car_id}", "CAR_0001");
                temp = temp.Replace("{car_cd}", "CAR_MB_0001");
                temp = temp.Replace("{pd_cd}", "PR_0001");
                temp = temp.Replace("{pd_symbol}", "@@@");
                temp = temp.Replace("{pr_name}", "Iphone 7");
                temp = temp.Replace("{distance}", "10");
                temp = temp.Replace("{quantity}", "100");
                temp = temp.Replace("{weight}", "0.5");
                temp = temp.Replace("{base_fee}", "99");
                temp = temp.Replace("{refund_fee}", "0");
                temp = temp.Replace("{relay_fee}", "0");
                temp = temp.Replace("{km_surcharge}", "0");
                temp = temp.Replace("{shipping_cd}", "SH_0001");
                temp = temp.Replace("{time_surcharge}", "0");
                temp = temp.Replace("{sp_money}", "0");
                temp = temp.Replace("{road_fee}", "0");
                temp = temp.Replace("{cleaning_fee}", "0");
                temp = temp.Replace("{truck_scale_fee}", "0");
                temp = temp.Replace("{other_fee}", "0");
                temp = temp.Replace("{adjusment_amount}", "0");
                temp = temp.Replace("{total}", "99");
                tempDetail += temp;
            }
            organizationInfo = organizationInfo.Replace("{organization_no}", "OR_0001");
            organizationInfo = organizationInfo.Replace("{transaction_name}", "Vận chuyển đường bộ");
            organizationInfo = organizationInfo.Replace("{pd_cd}", "PR_0001");
            organizationInfo = organizationInfo.Replace("{pd_symbol}", "@@@");
            organizationInfo = organizationInfo.Replace("{pr_name}", "Iphone 7");
            organizationInfo = organizationInfo.Replace("{distance}", "10");
            organizationInfo = organizationInfo.Replace("{quantity}", "100");
            organizationInfo = organizationInfo.Replace("{weight}", "0.5");
            organizationInfo = organizationInfo.Replace("{base_fee}", "99");
            organizationInfo = organizationInfo.Replace("{refund_fee}", "0");
            organizationInfo = organizationInfo.Replace("{relay_fee}", "0");
            organizationInfo = organizationInfo.Replace("{km_surcharge}", "0");
            organizationInfo = organizationInfo.Replace("{shipping_cd}", "SH_0001");
            organizationInfo = organizationInfo.Replace("{time_surcharge}", "0");
            organizationInfo = organizationInfo.Replace("{sp_money}", "0");
            organizationInfo = organizationInfo.Replace("{road_fee}", "0");
            organizationInfo = organizationInfo.Replace("{cleaning_fee}", "0");
            organizationInfo = organizationInfo.Replace("{truck_scale_fee}", "0");
            organizationInfo = organizationInfo.Replace("{other_fee}", "0");
            organizationInfo = organizationInfo.Replace("{adjusment_amount}", "0");
            organizationInfo = organizationInfo.Replace("{total}", "99");
            tempDetail += organizationInfo;

            
            inventoryDate = inventoryDate.Replace("{distance}", "10");
            inventoryDate = inventoryDate.Replace("{quantity}", "100");
            inventoryDate = inventoryDate.Replace("{weight}", "0.5");
            inventoryDate = inventoryDate.Replace("{base_fee}", "99");
            inventoryDate = inventoryDate.Replace("{refund_fee}", "0");
            inventoryDate = inventoryDate.Replace("{relay_fee}", "0");
            inventoryDate = inventoryDate.Replace("{km_surcharge}", "0");
            inventoryDate = inventoryDate.Replace("{shipping_cd}", "SH_0001");
            inventoryDate = inventoryDate.Replace("{time_surcharge}", "0");
            inventoryDate = inventoryDate.Replace("{sp_money}", "0");
            inventoryDate = inventoryDate.Replace("{road_fee}", "0");
            inventoryDate = inventoryDate.Replace("{cleaning_fee}", "0");
            inventoryDate = inventoryDate.Replace("{truck_scale_fee}", "0");
            inventoryDate = inventoryDate.Replace("{other_fee}", "0");
            inventoryDate = inventoryDate.Replace("{adjusment_amount}", "0");
            inventoryDate = inventoryDate.Replace("{total}", "99");
            tempDetail += inventoryDate;

            total = total.Replace("{distance}", "10");
            total = total.Replace("{quantity}", "100");
            total = total.Replace("{weight}", "0.5");
            total = total.Replace("{base_fee}", "99");
            total = total.Replace("{refund_fee}", "0");
            total = total.Replace("{relay_fee}", "0");
            total = total.Replace("{km_surcharge}", "0");
            total = total.Replace("{shipping_cd}", "SH_0001");
            total = total.Replace("{time_surcharge}", "0");
            total = total.Replace("{sp_money}", "0");
            total = total.Replace("{road_fee}", "0");
            total = total.Replace("{cleaning_fee}", "0");
            total = total.Replace("{truck_scale_fee}", "0");
            total = total.Replace("{other_fee}", "0");
            total = total.Replace("{adjusment_amount}", "0");
            total = total.Replace("{total}", "99");
            tempDetail += total;
            html = html.Replace("{table_content}", tempDetail);
            //GeneratePDF(html, css, "Shipping.pdf");
            GeneratePDFNReco(html,"NReco.pdf");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }


        public static void GeneratePDF(string html, string css, string fileName)
        {
            var cssData = PdfGenerator.ParseStyleSheet(css);
            var config = new PdfGenerateConfig();
            config.PageSize = PdfSharp.PageSize.A4;
            config.PageOrientation = PdfSharp.PageOrientation.Landscape;
            var doc = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, config);
           
            // Make a font and a brush to draw the page counter.
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            // Then use the font with the most language support
            XFont font = new XFont("Arial Unicode MS", 8, XFontStyle.Regular, options);
            XBrush brush = XBrushes.Black;
           
            
            // Add the page counter.
            string noPages = doc.Pages.Count.ToString();
            for (int i = 0; i < doc.Pages.Count; ++i)
            {
                PdfPage page = doc.Pages[i];
                
                XRect layoutRectangle = new XRect(0/*X*/, page.Height - font.Height/*Y*/, page.Width/*Width*/, font.Height/*Height*/);
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                  
                    gfx.MFEH = PdfFontEmbedding.Always;
                   
                    gfx.DrawString(
                        "Page " + (i + 1).ToString() + " of " + noPages,
                        font,
                        brush,
                        layoutRectangle,
                        XStringFormats.Center);
                }
            }
            doc.Save(fileName);
            doc.Close();
        }
    
        public static void GeneratePDFNReco(string html,string fileName)
        {
            var htmlToPdfConverter = new NReco.PdfGenerator.HtmlToPdfConverter();
            htmlToPdfConverter.CustomWkHtmlArgs = "  --print-media-type --title \"SMS Script 1 \" --dpi 300 --disable-smart-shrinking";
            htmlToPdfConverter.Size = NReco.PdfGenerator.PageSize.A3;
            var margins = new PageMargins();
            margins.Bottom = 4;
            margins.Top = 4;
            margins.Left = 5;
            margins.Right = 5;
            htmlToPdfConverter.Margins = margins;
            htmlToPdfConverter.Orientation = NReco.PdfGenerator.PageOrientation.Landscape;
            var pdfBytes = htmlToPdfConverter.GeneratePdf(html);
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(pdfBytes, 0, pdfBytes.Length);
            }
        }
    }
}
