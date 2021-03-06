﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Billogram
{
    public sealed partial class APIClient
    {
        /// <summary>
        /// Send an invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="method">The method of which to send the invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> SendInvoice(string id, InvoiceMethods.InvoiceSendMethod method)
        {
            var sendMethod = string.Empty;
            switch (method)
            {
                case InvoiceMethods.InvoiceSendMethod.Email:
                    sendMethod = "Email";
                    break;
                case InvoiceMethods.InvoiceSendMethod.SMS:
                    sendMethod = "SMS";
                    break;
                case InvoiceMethods.InvoiceSendMethod.Letter:
                    sendMethod = "Letter";
                    break;
                case InvoiceMethods.InvoiceSendMethod.EmailLetter:
                    sendMethod = "Email+Letter";
                    break;
                case InvoiceMethods.InvoiceSendMethod.SMSLetter:
                    sendMethod = "SMS+Letter";
                    break;
                case InvoiceMethods.InvoiceSendMethod.EFaktura:
                    sendMethod = "Efaktura";
                    break;
                case InvoiceMethods.InvoiceSendMethod.EDI:
                    sendMethod = "EDI";
                    break;
            }

            var url = $"{m_APIBaseURL}/billogram/{id}/command/send";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Sell an invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> SellInvoice(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/sell";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Re-send and invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="method">The method of which to resend the invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> ReSendInvoice(string id, InvoiceMethods.InvoiceResendMethod method)
        {
            var sendMethod = string.Empty;
            switch (method)
            {
                case InvoiceMethods.InvoiceResendMethod.Email:
                    sendMethod = "Email";
                    break;
                case InvoiceMethods.InvoiceResendMethod.SMS:
                    sendMethod = "SMS";
                    break;
                case InvoiceMethods.InvoiceResendMethod.Letter:
                    sendMethod = "Letter";
                    break;
            }

            var url = $"{m_APIBaseURL}/billogram/{id}/command/resend";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Send an invoice-reminder.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="method">The method of which to send the reminder.</param>
        /// <param name="message">The message attached with the reminder.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> SendInvoiceReminder(string id, InvoiceMethods.InvoiceReminderMethod method, string message)
        {
            var sendMethod = string.Empty;
            switch (method)
            {
                case InvoiceMethods.InvoiceReminderMethod.Email:
                    sendMethod = "Email";
                    break;
                case InvoiceMethods.InvoiceReminderMethod.SMS:
                    sendMethod = "SMS";
                    break;
                case InvoiceMethods.InvoiceReminderMethod.Letter:
                    sendMethod = "Letter";
                    break;
            }

            var url = $"{m_APIBaseURL}/billogram/{id}/command/remind";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod, message = message }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Send an invoice to the collector.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> SendInvoiceToCollector(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/collect";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Register payment to invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="amount">The total amount being registered.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> RegisterPaymentToInvoice(string id, double amount)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/payment";
            var jsonContent = JsonConvert.SerializeObject(new { amount = amount }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Credit an invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="amount">The total amount being credited.</param>
        /// <param name="creditMode">The type of credit being handed.</param>
        /// <param name="creditMethod">The method of which to credit.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> CreditInvoice(string id, double amount, InvoiceMethods.InvoiceCreditMode creditMode, InvoiceMethods.InvoiceCreditMethod creditMethod)
        {

            var mode = string.Empty;
            var method = string.Empty;

            switch (creditMode)
            {
                case InvoiceMethods.InvoiceCreditMode.Full:
                    mode = "full";
                    break;
                case InvoiceMethods.InvoiceCreditMode.Remaining:
                    mode = "remaining";
                    break;
                case InvoiceMethods.InvoiceCreditMode.Amount:
                    mode = "amount";
                    break;
                case InvoiceMethods.InvoiceCreditMode.Principal:
                    mode = "principal";
                    break;
                case InvoiceMethods.InvoiceCreditMode.Rest:
                    mode = "rest";
                    break;
            }


            switch (creditMethod)
            {
                case InvoiceMethods.InvoiceCreditMethod.Email:
                    method = "Email";
                    break;
                case InvoiceMethods.InvoiceCreditMethod.SMS:
                    method = "SMS";
                    break;
                case InvoiceMethods.InvoiceCreditMethod.Letter:
                    method = "Letter";
                    break;
                case InvoiceMethods.InvoiceCreditMethod.Efaktura:
                    method = "Efaktura";
                    break;
                case InvoiceMethods.InvoiceCreditMethod.EDI:
                    method = "EDI";
                    break;
                case InvoiceMethods.InvoiceCreditMethod.DoNotNotify:
                    method = "DoNotNotify";
                    break;
            }

            var url = $"{m_APIBaseURL}/billogram/{id}/command/credit";
            var jsonContent = JsonConvert.SerializeObject(new { amount = amount, mode = mode, method = method }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Write off an invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> WriteOffInvoice(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/writeoff";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Write-down an invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> WriteDownInvoice(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/writedown";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Revert write-down.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> RevertWriteDown(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/revert-writedown";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Set invoice respite.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="date">The date to which the respite will be set. MUST BE SET TO A FUTURE DATE AND AFTER BILLOGRAM DUE DATE.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> SetInvoiceRespite(string id, Structures.BillogramDate date)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/respite";
            var jsonContent = JsonConvert.SerializeObject(new { date = date.Format() }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Remove invoice respite.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> RemoveInvoiceRespite(string id)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/remove-respite";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Add message to Invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="message">The message to be added.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> AddMessageeToInvoice(string id, string message)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/message";
            var jsonContent = JsonConvert.SerializeObject(new { message = message }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Add a PDF-attachment to invoice.
        /// </summary>
        /// <param name="id">The id of unique invoice.</param>
        /// <param name="filename">The name of the file.</param>
        /// <param name="content">The content (base64 encoded) of the PDF file that you wish to attach.</param>
        /// <returns>The updated data of the invoice.</returns>
        public async Task<Structures.Invoice.Unique> AddPDFAttachmentToInvoice(string id, string filename, string content)
        {
            var url = $"{m_APIBaseURL}/billogram/{id}/command/attach";
            var jsonContent = JsonConvert.SerializeObject(new { filename = filename, content = content }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<Structures.Invoice.Unique>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
    }

    public struct InvoiceMethods
    {
        public enum InvoiceSendMethod
        {
            Email,
            SMS,
            Letter,
            EmailLetter,
            SMSLetter,
            EFaktura,
            EDI
        }
        public enum InvoiceResendMethod
        {
            Email,
            SMS,
            Letter,
        }
        public enum InvoiceReminderMethod
        {
            Email,
            SMS,
            Letter,
        }
        public enum InvoiceCreditMode
        {
            Full,
            Remaining,
            Amount,
            Principal,
            Rest
        }
        public enum InvoiceCreditMethod
        {
            Email,
            SMS,
            Letter,
            Efaktura,
            EDI,
            DoNotNotify
        }
    }
}
