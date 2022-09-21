namespace Bolletta
{
    class CaldaiaT : Macchinari
    {
        public CaldaiaT()
        {
            this.acquisto = 1500;
            this.installazione = 300;
            this.rendimento = 0.9;
            this.costoMateria = 1.05;
            this.tipoConsumo = "gas";
        }

        public override void Utilizzo(double consumo)
        {
            this.utilizzo = consumo / (this.pt * this.rendimento);
        }
    }
}