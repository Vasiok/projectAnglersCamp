using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {

        public WaterlevelBs waterLevelBs { get; set; }
        public ReportBs reportBs { get; set; }
        public MembersBs memberBs { get; set; }
        public ClubsBs clubsBs { get; set; }
        public AWLevelBs Levels { get; set; }

        public BaseBs()
        {
            waterLevelBs = new WaterlevelBs();
            reportBs = new ReportBs();
            memberBs = new MembersBs();
            clubsBs = new ClubsBs();
            Levels = new AWLevelBs();
        }


    }
}
