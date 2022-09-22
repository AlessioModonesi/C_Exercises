namespace Bolletta
{
    class PompaEco : Macchinari
    {
        public PompaEco()
        {
            this.acquisto = 1000;
            this.installazione = 250;
            this.rendimento = 2.8;
            this.costoMateria = 0.28;
            this.tipoConsumo = "luce";
        }

        public override void Utilizzo(double consumo)
        {
            this.utilizzo = consumo * (this.pt / this.rendimento);
        }
    }
}