﻿namespace Billogram.Query
{
    public sealed class ReportsParamQuery : QuerySearchParameter
    {
        /// <summary>
        /// Name of the field to search in.
        /// </summary>
        public SearchField Search_Field { get; set; }
        /// <summary>
        /// Name of the field to order the results by. 
        /// </summary>
        public OrderField Order_Field { get; set; }

        private string FilterParam()
        {
            string temp = "";
            switch (Filter_Type)
            {
                case FilterType.None:
                    return temp;
                case FilterType.Field:
                    temp += "&filter_type=field";
                    break;
                case FilterType.FieldPrefix:
                    temp += "&filter_type=field-prefix";
                    break;
                case FilterType.FieldSearch:
                    temp += "&filter_type=field-search";
                    break;
                case FilterType.Special:
                    temp += "&filter_type=special";
                    break;
            }
            switch (Search_Field)
            {
                case SearchField.Filename:
                    temp += "&filter_field=filename";
                    break;
            }
            return temp;
        }
        private string OrderParam()
        {
            string temp = "";
            switch (Order_Field)
            {
                case OrderField.None:
                    return temp;
                case OrderField.Filename:
                    temp += "&order_field=filename";
                    break;
                case OrderField.Created_At:
                    temp += "&order_field=created_at";
                    break;
            }
            return temp + GetOrderDirection;
        }
        public override string Param()
        {
            return base.Param() + FilterParam() + OrderParam();
        }

        /// <summary>
        /// Name of the field to search in.
        /// </summary>
        public enum SearchField
        {
            Filename
        }

        /// <summary>
        /// Name of the field to order the results by. 
        /// </summary>
        public enum OrderField
        {
            None,
            Filename,
            Created_At
        }
    }
}
