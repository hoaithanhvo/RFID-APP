namespace RFHandheld
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class InputValidation
    {
        static readonly int Length = 16;
        static readonly string start = "1300010";
        static readonly string pattern = @"^[A-P]-([0][1-9]|1[0-9]|2[0-6])-([1-3])-1$";

        public static async Task<string> LocationValidation(string input, string Location)
        {
            if (Location != string.Empty && input == Location)
            {
                // Same Location as suggested
                return "OK";
            }
            if (Regex.IsMatch(input, pattern))
            {
                // Location scan first or different Location
                // If location scan first then we also could not check if same location as RFID
                // Thus we generalize the check function to only accept Location that can still put pallet
                // If it is indeed same location as RFID, then user need to scan RFID first then this function will return true at the very beginning
                // Check location status in Layout DB
                var validation = await API.CHECK_LOCATION_STATUS(input);
                return validation;
            }
            return "FORMAT";
        }

        public static async Task<Tuple<int, List<RfidInfo>>> EpcValidation(string input)
        {
            if (input.Length == Length && input.StartsWith(start))
            {
                var result = await API.GET_RFID_INFORMATION(input);
                return result;
            }
            return Tuple.Create(2, new List<RfidInfo>());
        }

        public static async Task<Tuple<int, QR_INFORMATION>> QrValidation(string input, List<string> QR)
        {
            // call api here to check if QR already mapped
            if (QR.Exists(qr => qr.Equals(input)))
                return Tuple.Create(3, new QR_INFORMATION()); // Duplication - already scanned
            if (input.Length == 63)
            {
                string iMaterial = input.Substring(0, 20);
                foreach (var item in QR)
                {
                    string Material = item.Substring(0, 20);
                    if (Material != iMaterial)
                        return Tuple.Create(1, new QR_INFORMATION()); // Different MaterialCode
                }
                var result = await API.GET_QR_INFORMATION(input);
                if (result.Item1 == 1)
                {
                    if (result.Item2.Description != "NOT FOUND" && result.Item2.Description != "MAPPED")
                    {
                        return Tuple.Create(0, result.Item2);
                    }
                    else if (result.Item2.Description == "NOT FOUND")
                    {
                        return Tuple.Create(4, new QR_INFORMATION()); // Desciption not found
                    }
                    else
                    {
                        return Tuple.Create(5, new QR_INFORMATION()); // QR already mapped
                    }
                }
                else
                {
                    return Tuple.Create(6, result.Item2); // API error
                }
            }
            return Tuple.Create(2, new QR_INFORMATION()); // Wrong length
        }
    }

    public class QR_INFORMATION
    {
        public string MaterialCode { get; set; }
        public string Description { get; set; }
        public string LotNumber { get; set; }
        public string Quantity { get; set; }
        public string Box { get; set; }

        public static List<QR_INFORMATION> InitialList()
        {
            return new List<QR_INFORMATION>
            {
                new QR_INFORMATION()
                {
                    MaterialCode = "Material",
                    Description = "Description",
                    LotNumber = "Lot",
                    Quantity = "Qty",
                    Box = "Box"
                }
            };
        }
    }

    public class RfidInfo
    {
        public string Location { get; set; }
        public string MaterialCode { get; set; }
        public string LotNumber { get; set; }
        public string Quantity { get; set; }
        public string Box { get; set; }

        public static List<RfidInfo> InitialList()
        {
            return new List<RfidInfo>()
            {
                new RfidInfo()
                {
                    Location = "Location",
                    MaterialCode = "Material",
                    LotNumber = "Lot",
                    Quantity = "Qty",
                    Box = "Box"
                }
            };
        }
    }

    public class PickingListInfo
    {
        public string No { get; set; }
        public string PickingNo { get; set; }
        public string LocTo { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }

        public static List<PickingListInfo> InitialList()
        {
            return new List<PickingListInfo>()
            {
                new PickingListInfo()
                {
                    No = "No",
                    PickingNo = "PickingNo",
                    LocTo = "LocTo",
                    Time = "Time",
                    Status = "Status"
                }
            };
        }
    }

    public class TrackingInfo
    {
        public string Location { get; set; }
        public string EPC { get; set; }
        public string MaterialCode { get; set; }
        public string LotNumber { get; set; }
        public string Quantity { get; set; }
        public string Box { get; set; }

        public static List<TrackingInfo> InitialList()
        {
            return new List<TrackingInfo>()
            {
                new TrackingInfo()
                {
                    Location = "Location",
                    EPC = "EPC",
                    MaterialCode = "Material",
                    LotNumber = "Lot",
                    Quantity = "Qty",
                    Box = "Box"
                }
            };
        }
    }

    public class PalletInfo
    {
        public string MaterialCode { get; set; }
        public string LotNumber { get; set; }
        public string Quantity { get; set; }
        public string Box { get; set; }

        public static List<PalletInfo> InitialList()
        {
            return new List<PalletInfo>()
            {
                new PalletInfo()
                {
                    MaterialCode = "Material",
                    LotNumber = "Lot",
                    Quantity = "Qty",
                    Box = "Box"
                }
            };
        }
    }

    public class MAPPING_BODY
    {
        public string EPC { get; set; }
        public List<QrBody> QR { get; set; }
    }

    public class MovingPalletBody
    {
        public string OriEPC { get; set; }
        public string NewEPC { get; set; }
        public List<QrBody> QR { get; set; }
    }

    public class QrBody
    {
        public string Value { get; set; }
    }
}