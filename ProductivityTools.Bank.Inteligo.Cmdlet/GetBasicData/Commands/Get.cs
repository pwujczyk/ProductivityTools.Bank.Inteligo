using ProductivityTools.ConsoleColor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Bank.Inteligo.Cmdlet.GetBasicData.Commands
{
    class Get : InteligoCommandBase<GetBasicDataCmdlet>
    {
        public Get(GetBasicDataCmdlet cmdletType) : base(cmdletType)
        {
        }

        protected override bool Condition => true;

        protected override void Invoke()
        {
            var basicdata= this.InteligoApplication.GetBasicData(this.Login, this.Password,this.Cmdlet.ShowBrowser);
            Console.WriteLine();
            foreach(var data in basicdata)
            {
                var text = new ColorString();
                text.Add(new ColorStringItem(data.Account.PadRight(15, ' '), 82));
                text.Add(new ColorStringItem(data.AvailiableFunds.ToString(),226));

                ConsoleColors.WriteInColor(text);
            }
        }
    }
}
