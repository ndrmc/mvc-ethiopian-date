using System;
using System.Web.Mvc;
using System.Web;



namespace EthCal
{
    public static class AmharicCalender
    {
        public static MvcHtmlString AmCal(this HtmlHelper helper, string id)
        {


            string amid = id + "_am";
            var scrips = string.Format(@"<link href='/Scripts/js/humanity.calendars.picker.css' rel='stylesheet' type='text/css'/>
                                 <script type='text/javascript' src='/Scripts/2012.1.419/telerik.calendar.min.js')'></script>
                                 <script type='text/javascript' src='/Scripts/2012.1.419/telerik.datepicker.min.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.plus.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.picker.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.ethiopian.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.picker-am.js')'> </script>
                                 <script type='text/javascript' src='/Scripts/js/jquery.calendars.ethiopian-am.js')'> </script>");


            string headerFiles = string.Format(@"<input id='{0}' class='calendarspicker t-input' type='input' data-gregorian-field='input[name={1}]' />", amid, id);





            var fun = @"<script type='text/javascript'>

             $(function() {

                 $('.calendarspicker').calendarsPicker({
                     calendar: $.calendars.instance('ethiopian', 'am')
                     //disableInput: true
                 }).attr('readonly', 'readonly').attr('style', 'background-color : #fff');

                 $.calendars.picker.setDefaults({ dateFormat: 'dd-MMM-yyyy' });
                 //set the receipt hidden date using the telrik date picker control
                 var eCalendar = $.calendars.instance('ethiopian', 'am');
                 var valueToset = new Date();
                 if ($('#@id').data('tDatePicker').value() != null) {
                     valueToset = $('#@id').data('tDatePicker').value();
                 }
                 var jstartdate = eCalendar.fromJSDate(valueToset).toJD();
                 var edate = eCalendar.fromJD(jstartdate);
                 //set the Amharic respective
                 $('#@amid').val(edate.formatDate('dd-MMM-yyyy'));
                 $('#@id').val($.datepicker.formatDate('dd-M-yy', valueToset));
             });
         </script>";


            HttpContextBase context = helper.ViewContext.HttpContext;
            // don't add the file if it's already there
            if (context.Items.Contains(scrips) && context.Items.Contains(fun))
                return MvcHtmlString.Create(headerFiles);
            else
            {
                context.Items.Add(scrips, scrips);
                context.Items.Add(fun, fun);
            }
            return MvcHtmlString.Create(scrips + headerFiles + fun);
        }


    }


}