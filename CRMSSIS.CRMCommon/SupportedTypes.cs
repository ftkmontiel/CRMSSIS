﻿using Microsoft.Xrm.Sdk.Metadata;
using System;

namespace CRMSSIS.CRMCommon
{
    public static class SupportedTypes
    {

        public static Boolean isValidAttribute(AttributeMetadata attribute)
        {

            return isValidAttribute(attribute, null);
        }
        /// filter some types of attributes based on operation or not supported
        /// </summary>
        public static Boolean isValidAttribute(AttributeMetadata attribute, int? Operation)
        {
            bool valid = false;

            //Create/Update Operation or default types
            if (!Operation.HasValue || Operation == 0 || Operation == 1)
            {
                switch (attribute.AttributeType.Value)
                {
                    case AttributeTypeCode.Customer:
                    case AttributeTypeCode.Picklist:
                    case AttributeTypeCode.Owner:
                    case AttributeTypeCode.Lookup:
                    case AttributeTypeCode.Decimal:
                    case AttributeTypeCode.Boolean:
                    case AttributeTypeCode.BigInt:
                    case AttributeTypeCode.DateTime:
                    case AttributeTypeCode.Double:
                    case AttributeTypeCode.Integer:
                    case AttributeTypeCode.Money:
                    case AttributeTypeCode.PartyList:
                    case AttributeTypeCode.Memo:
                    case AttributeTypeCode.String:
                    case AttributeTypeCode.Uniqueidentifier:
                        valid = true;
                        break;

                }
            }
            //Delete Operation
            if (Operation.HasValue && Operation == 2 && attribute.AttributeType.Value == AttributeTypeCode.Uniqueidentifier) valid = true;

            //Status Operation
            if (Operation.HasValue && Operation == 3 && (attribute.AttributeType.Value == AttributeTypeCode.Uniqueidentifier || attribute.AttributeType.Value == AttributeTypeCode.State || attribute.AttributeType.Value == AttributeTypeCode.Status)) valid = true;


            return valid;
        }
    }
}