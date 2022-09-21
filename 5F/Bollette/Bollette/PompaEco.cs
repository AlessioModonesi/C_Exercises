namespace Bollette
{
    class PompaEco : Macchinari
    {
        public PompaEco()
        {
            this.acquisto = 1000;
            this.installazione = 250;
            this.rendimento = 2.8;
            this.costoMateria = 1.05;
            this.tipoConsumo = "gas";
        }

        public override void Utilizzo(double consumo)
        {
            this.utilizzo = consumo / (this.pt * this.rendimento);
        }
    }
}