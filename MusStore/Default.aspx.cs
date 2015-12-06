using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MusStore.Services;


namespace MusStore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {


                PairIntegrationService.Pair p1 = new PairIntegrationService.Pair();
                p1.First = Convert.ToInt32(txtP1First.Text);
                p1.Second = Convert.ToInt32(txtp1Second.Text);

                PairIntegrationService.Pair p2 = new PairIntegrationService.Pair();
                p2.First = Convert.ToInt32(txtP2First.Text);
                p2.Second = Convert.ToInt32(txtp2Second.Text);

                PairIntegrationService.PairIntegrationService pairServiceClient = new PairIntegrationService.PairIntegrationService();
                PairIntegrationService.Pair addResult = pairServiceClient.Add(p1, p2);

                PairIntegrationService.Pair minusResult = pairServiceClient.Substract(p1, p2);

                lblsum.Text = addResult.First.ToString() + ", " + addResult.Second.ToString();
                lblminus.Text = minusResult.First.ToString() + ", " + minusResult.Second.ToString();
            }
            catch (Exception ex)
            {
                //Pokemon exception handling
              
            }
        }
    }
}