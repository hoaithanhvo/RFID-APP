//#define LOCAL
namespace RFHandheld
{
    using System;
    using System.Net;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    class API
    {
#if !LOCAL
        const string POST_MAP = "http://10.234.1.39:1234/api/mapping";
        const string POST_MOVE = "http://10.234.1.39:1234/api/move";
        const string GET_QR = "http://10.234.1.39:1234/api/getQR";
        const string POST_PUT = "http://10.234.1.39:1234/api/put";
        const string GET_RFID = "http://10.234.1.39:1234/api/getRFID";
        const string GET_PALLET = "http://10.234.1.39:1234/api/getPallet";
        const string POST_MOVE_PALLET_QR = "http://10.234.1.39:1234/api/PalletQrMove";
        const string GET_TRACKING = "http://10.234.1.39:1234/api/tracking";
        const string CHECK_LOCATION = "http://10.234.1.39:1234/api/checkLocation";
        const string GET_PICKING_LIST = "http://10.234.1.39:1234/api/getPickingList";
        const string DELETE_MAP = "http://10.234.1.39:1234/api/deleteMapping";
#else
        const string POST_MAP = "http://192.168.8.106:12345/api/mapping";
        const string POST_MOVE = "http://192.168.8.106:12345/api/move";
        const string GET_QR = "http://192.168.8.106:12345/api/getQR";
        const string POST_PUT = "http://192.168.8.106:12345/api/put";
        const string GET_RFID = "http://192.168.8.106:12345/api/getRFID";
        const string GET_PALLET = "http://192.168.8.106:12345/api/getPallet";
        const string POST_MOVE_PALLET_QR = "http://192.168.8.106:12345/api/PalletQrMove";
        const string GET_TRACKING = "http://192.168.8.106:12345/api/tracking";
        const string CHECK_LOCATION = "http://192.168.8.106:12345/api/checkLocation";
        const string GET_PICKING_LIST = "http://192.168.8.106:12345/api/getPickingList";
        const string DELETE_MAP = "http://192.168.8.106:12345/api/deleteMapping";
#endif
        public static async Task<Tuple<int, QR_INFORMATION>> GET_QR_INFORMATION(string QR)
        {
            int result = 0;
            QR_INFORMATION temp = new QR_INFORMATION();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GET_QR);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"QR", QR },
                    });

                    var query = url_content.ReadAsStringAsync().Result;

                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = 1;
                            temp = JsonConvert.DeserializeObject<QR_INFORMATION>(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                temp.MaterialCode = e.Message;
                temp.Description = e.Message;
                temp.LotNumber = e.Message;
                temp.Quantity = e.Message;
                temp.Box = e.Message;
            }
            return Tuple.Create(result, temp);
        }

        public static async Task<Tuple<int, List<RfidInfo>>> GET_RFID_INFORMATION(string RFID)
        {
            int result = 0;
            List<RfidInfo> temp = new List<RfidInfo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GET_RFID);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"EPC", RFID },
                    });

                    var query = url_content.ReadAsStringAsync().Result;

                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = 1;
                            temp = JsonConvert.DeserializeObject<List<RfidInfo>>(await response.Content.ReadAsStringAsync());
                            temp.Select(item =>
                            {
                                if (item.Location == null || item.Location == string.Empty)
                                {
                                    item.Location = "No location";
                                }
                                return item;
                            }).ToList();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var error = new RfidInfo()
                {
                    Location = e.Message,
                    MaterialCode = e.Message,
                    LotNumber = e.Message,
                    Quantity = e.Message,
                    Box = e.Message
                };
                temp.Add(error);
            }
            return Tuple.Create(result, temp);
        }

        public static async Task<Tuple<int, List<PalletInfo>>> GET_PALLET_INFORMATION(string RFID)
        {
            int result = 0;
            List<PalletInfo> temp = new List<PalletInfo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GET_PALLET);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"EPC", RFID },
                    });

                    var query = url_content.ReadAsStringAsync().Result;

                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = 1;
                            temp = JsonConvert.DeserializeObject<List<PalletInfo>>(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var error = new PalletInfo()
                {
                    MaterialCode = e.Message,
                    LotNumber = e.Message,
                    Quantity = e.Message,
                    Box = e.Message
                };
                temp.Add(error);
            }
            return Tuple.Create(result, temp);
        }

        public static async Task<string> CHECK_LOCATION_STATUS(string LOC)
        {
            string result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(CHECK_LOCATION);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"LOC", LOC },
                    });

                    var query = url_content.ReadAsStringAsync().Result;
                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static async Task<string> POST_MAPPING(string RFID, List<string> QR)
        {
            string result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var body = new MAPPING_BODY()
                    {
                        EPC = RFID,
                        QR = new List<QrBody>()
                    };
                    for (int i = 0; i < QR.Count; i++)
                    {
                        var item = new QrBody()
                        {
                            Value = QR[i]
                        };
                        body.QR.Add(item);
                    }

                    var jsonBody = JsonConvert.SerializeObject(body);
                    var content = new StringContent(jsonBody, null, "application/json");
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{POST_MAP}")
                    {
                        Content = content
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static async Task<string> DELETE_MAPPING(string RFID)
        {
            string result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(DELETE_MAP);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"EPC", RFID },
                    });

                    var query = url_content.ReadAsStringAsync().Result;
                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static async Task<string> POST_MOVING_PALLET_QR(string OriEPC, string NewEPC, List<string> QR)
        {
            string result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var body = new MovingPalletBody()
                    {
                        OriEPC = OriEPC,
                        NewEPC = NewEPC,
                        QR = new List<QrBody>()
                    };
                    for (int i = 0; i < QR.Count; i++)
                    {
                        var item = new QrBody()
                        {
                            Value = QR[i]
                        };
                        body.QR.Add(item);
                    }

                    var jsonBody = JsonConvert.SerializeObject(body);
                    var content = new StringContent(jsonBody, null, "application/json");
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{POST_MOVE_PALLET_QR}")
                    {
                        Content = content
                    };

                    using (var response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static async Task<string> PUT_IN(string RFID, string LOC)
        {
            string temp = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"LOC", LOC },
                        {"EPC", RFID },
                    });
                    var query = url_content.ReadAsStringAsync().Result;

                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{POST_PUT}?{query}"))
                    {
                        var response = await client.SendAsync(request);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            temp = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                temp = e.Message;
            }
            return temp;
        }

        public static async Task<string> MOVE(string RFID, string LOC)
        {
            string temp = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"LOC", LOC },
                        {"EPC", RFID },
                    });
                    var query = url_content.ReadAsStringAsync().Result;

                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{POST_MOVE}?{query}"))
                    {
                        var response = await client.SendAsync(request);
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            temp = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                temp = e.Message;
            }
            return temp;
        }

        public static async Task<Tuple<int,List<TrackingInfo>>> GET_TRACKING_INFORMATION(int mode, string input)
        {
            int result = 0;
            List<TrackingInfo> temp = new List<TrackingInfo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GET_TRACKING);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"input", input },
                        {"mode", mode.ToString() },
                    });

                    var query = url_content.ReadAsStringAsync().Result;

                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = 1;
                            temp = JsonConvert.DeserializeObject<List<TrackingInfo>>(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var error = new TrackingInfo()
                {
                    Location = e.Message,
                    EPC = e.Message,
                    MaterialCode = e.Message,
                    LotNumber = e.Message,
                    Quantity = e.Message,
                    Box = e.Message
                };
                temp.Add(error);
            }
            return Tuple.Create(result, temp);
        }

        public static async Task<Tuple<int, List<PickingListInfo>>> GET_LIST_PICKINGLIST(string dateFrom, string dateTo)
        {
            int result = 0;
            List<PickingListInfo> temp = new List<PickingListInfo>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GET_PICKING_LIST);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var url_content = new FormUrlEncodedContent(new Dictionary<string, string>()
                    {
                        {"from", dateFrom },
                        {"to", dateTo },
                    });

                    var query = url_content.ReadAsStringAsync().Result;
                    using (var response = await client.GetAsync($"{client.BaseAddress}?{query}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            result = 1;
                            temp = JsonConvert.DeserializeObject<List<PickingListInfo>>(await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var error = new PickingListInfo()
                {
                    No = e.Message,
                    PickingNo = e.Message,
                    LocTo = e.Message,
                    Time = e.Message,
                    Status = e.Message
                };
                temp.Add(error);
            }
            return Tuple.Create(result, temp);
        }
    }
}