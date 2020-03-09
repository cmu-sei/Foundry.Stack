/*
Foundry
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon(R) and CERT(R) are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0194
*/

using Stack.Patterns.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack.Patterns.Service
{
    public static class StringExtensions
    {
        /// <summary>
        /// checks if an enum exists in a string array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Contains(this string[] array, Enum value)
        {
            return array.Select(p => p.ToLower()).Contains(value.ToString().ToLower());
        }

        /// <summary>
        /// converts a string into a collection of filter key values
        /// </summary>
        /// <param name="filter">filter1|filter2|filter3=value,value,value</param>
        /// <returns></returns>
        public static List<FilterKeyValue> ToFilterKeyValues(this string filter)
        {
            var keyValues = new List<FilterKeyValue>();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                var filters = filter.ToLower().Trim().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var f in filters)
                {
                    var keyValue = new FilterKeyValue(f);

                    if (!keyValues.Any(kv => kv.Key == keyValue.Key))
                    {
                        keyValues.Add(keyValue);
                    }
                }
            }

            return keyValues;
        }
    }
}
