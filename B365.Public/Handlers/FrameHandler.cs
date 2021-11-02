using System.Collections.Generic;
using System.Linq;
using B365.Public.Enums;
using B365.Public.Extensions;

namespace B365.Public.Handlers
{
    internal record FrameState
    {
        public string XorKey { get; set; }
    }

    public static class FrameHandler
    {
        /// <summary>
        /// parse each "game" and their respective "columns" for a "frame"
        /// </summary>
        /// <param name="frame"></param>
        public static EStatusCode Parse(string frame)
        {
            //
            if (string.IsNullOrEmpty(frame)) return EStatusCode.EmptyFrame;
            
            // ensure 'frame'
            if (frame[0] != 'F') return EStatusCode.InvalidFrame;

            //
            var state = new FrameState();

            var games = frame.SplitOnEnum(EStandardProtocolConstants.GameDelim);
            foreach (var game in games)
            {
                var cols = game.SplitOnEnum(EStandardProtocolConstants.ColumnDelim);
                if (cols.Count == 1) continue;

                var obj = ColumnsToObject(cols);
                switch (cols.First())
                {
                    // classification
                    case "CL":
                        if (obj.ContainsKey("TK")) state.XorKey = obj["TK"];
                        break;

                    // competition
                    case "CT":
                        break;

                    // event
                    case "EV":
                        break;

                    // market
                    case "MA":
                        break;

                    // ?
                    case "MG":
                        break;

                    // participant
                    case "PA":
                        if (obj.ContainsKey("OD") && state.XorKey.Length > 0)
                        {
                            var odds = PublicUtils.XorDecrypt(obj["OD"], state.XorKey);
                            var dec = PublicUtils.FractionToDecimal(odds);
                        }
                        break;
                }
            }
            
            return EStatusCode.Success;
        }

        /// <summary>
        /// parse each "k=v" column of a "game"
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static Dictionary<string, string> ColumnsToObject(List<string> fields)
        {
            var obj = new Dictionary<string, string>();
            foreach (var field in fields)
            {
                var split = field.Split("=", 2);
                obj.Add(split.First(), split.Last());
            }

            return obj;
        }
    }
}