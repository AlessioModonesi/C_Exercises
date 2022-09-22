namespace Bolletta
{
    class CaldaiaC : Macchinari
    {
        public CaldaiaC()
        {
            this.acquistoMacchinario = 1500;
            this.installazioneMacchinario = 300;
            this.rendimentoMacchinario = 1;
            this.tipoConsumo = "gas";
        }

        public override void UtilizzoAnnuale(double consumo)
        {
            this.utilizzoAnnuale = consumo / (this.potereCalorifico * this.rendimentoMacchinario);
        }
    }
}