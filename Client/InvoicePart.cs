﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Billogram 
{
    public sealed partial class BillogramClient
    {
      

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

            var url = $"{m_baseURL}/billogram/{id}/command/send";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod}, Formatting.Indented);
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
        public async Task<Structures.Invoice.Unique> SellInvoice(string id)
        {
            var url = $"{m_baseURL}/billogram/{id}/command/sell";
            var jsonContent = JsonConvert.SerializeObject(new { }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url,dataContent);
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

            var url = $"{m_baseURL}/billogram/{id}/command/resend";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod }, Formatting.Indented);
            var dataContent = new StringContent(jsonContent);
            try
            {
                var response = await m_client.PostAsync(url, dataContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<T>(responseBody);
                return deserializedObject;
            }
            catch
            {
                return null;
            }
        }
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

            var url = $"{m_baseURL}/billogram/{id}/command/remind";
            var jsonContent = JsonConvert.SerializeObject(new { method = sendMethod, message = message}, Formatting.Indented);
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
        public async Task<Structures.Invoice.Unique> SendInvoiceToCollector(string id)
        {
            var url = $"{m_baseURL}/billogram/{id}/command/collect";
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
        public async Task<Structures.Invoice.Unique> RegisterPaymentToInvoice(string id, double amount)
        {
            var url = $"{m_baseURL}/billogram/{id}/command/payment";
            var jsonContent = JsonConvert.SerializeObject(new { amount = amount }, Formatting.Indented);
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
        public async Task<Structures.Invoice.Unique> RegisterPaymentToInvoice(string id, double amount, InvoiceMethods.InvoiceCreditMode creditMode, InvoiceMethods.InvoiceCreditMethod creditMethod)
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

            var url = $"{m_baseURL}/billogram/{id}/command/credit";
            var jsonContent = JsonConvert.SerializeObject(new { amount = amount, mode = mode, method = method}, Formatting.Indented);
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