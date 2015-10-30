//Activity Selection for non-overlapping intervals
        public static int findmaxNew(List<string> lstIn)
        {
            int cnt = 0;
            List<int> startTime = new List<int>() { };
            List<int> endTime = new List<int>() { };

            List<string> modifiedIn = new List<string>();
            List<string> modifiedOut = new List<string>();
            foreach (string str in lstIn)
            {
                string endStr = "0" + str.Split(new string[] { "#" }, StringSplitOptions.None)[1];
                endStr = endStr.Substring(endStr.Length - 2);
                string startStr = "0" + str.Split(new string[] { "#" }, StringSplitOptions.None)[0];
                startStr = startStr.Substring(startStr.Length - 2);
                modifiedIn.Add(endStr + "#" + startStr);
            }
            modifiedIn.Sort();
            modifiedIn.ForEach(obj => { startTime.Add(Convert.ToInt16(obj.Split(new string[] { "#" }, StringSplitOptions.None)[1])); endTime.Add(Convert.ToInt16(obj.Split(new string[] { "#" }, StringSplitOptions.None)[0])); });
            modifiedOut.Add(modifiedIn[0]);
            int k = 0;
            for (int i = 1; i < modifiedIn.Count; i++)
            {
                if (startTime[i] >= endTime[k])
                {
                    modifiedOut.Add(modifiedIn[i]);
                    k = i;
                }
            }
            modifiedOut = modifiedOut.Distinct().ToList();
            cnt = modifiedOut.Count;
            return cnt;
        }
