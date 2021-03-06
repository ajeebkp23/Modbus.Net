﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using CrossLampControl.WebApi.Models;
using Modbus.Net;
using Modbus.Net.Siemens;

namespace CrossLampControl.WebApi.Controllers
{
    public class CrossLampController : ApiController
    {
        BaseUtility _utility;

        public CrossLampController()
        {
            _utility = new SiemensUtility(SiemensType.Tcp, "192.168.3.241", SiemensMachineModel.S7_200);
            _utility.AddressTranslator = new AddressTranslatorSiemens();
        }

        [HttpGet]
        public Lamp GetLamp()
        {
            Lamp light = new Lamp();
            object[] lampsbyte = _utility.GetDatas(2, 0, "Q 0", new KeyValuePair<Type, int>(typeof(bool), 7));
            bool[] lamps =
                BigEndianValueHelper.Instance.ObjectArrayToDestinationArray<bool>(
                    lampsbyte);
            if (lamps[0])
            {
                light.MainLamp = LightLamp.Green.ToString();
            }
            else if (lamps[1])
            {
                light.MainLamp = LightLamp.Yellow.ToString();
            }
            else
            {
                light.MainLamp = LightLamp.Red.ToString();
            }
            if (lamps[3])
            {
                light.SubLamp = LightLamp.Green.ToString();
            }
            else if (lamps[4])
            {
                light.SubLamp = LightLamp.Yellow.ToString();
            }
            else
            {
                light.SubLamp = LightLamp.Red.ToString();
            }
            light.SetStart(lamps[6]);
            return light;
        }
    }
}