using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falures
{
    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            var date = new DateTime(year, month, day);
            var failures = new List<Failure>();

            for(var i = 0; i < failureTypes.Length; i++)
            {
                var failure = new Failure();
                failure.DeviceID = deviceId[i];
                failure.Time = new DateTime((int)times[i][2], (int)times[i][1], (int)times[i][0]);
                failure.Type = (FailureType)failureTypes[i];
                failures.Add(failure);
            }

            var devicesList = new List<Device>();

            foreach(var device in devices)
                devicesList.Add(new Device {
                    Name = device["Name"] as string, 
                    DeviceID = (int)device["DeviceId"] });

            return FindDevicesFailedBeforeDate(date, failures, devicesList)
                .Select(device => device.Name)
                .ToList();
        }

        public static List<Device> FindDevicesFailedBeforeDate(
            DateTime date, 
            List<Failure> failures, 
            List<Device> devices)
        {
            var problematicDevices = new HashSet<int>();

            foreach (var failure in failures)
                if (failure.IsSerious() && failure.Time < date)
                    problematicDevices.Add(failure.DeviceID);

            var result = new List<Device>();

            foreach (var device in devices)
                if (problematicDevices.Contains(device.DeviceID))
                    result.Add(device);

            return result;
        }

    }
}
