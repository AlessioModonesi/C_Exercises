namespace Bolletta
{
    class Pompa : Macchinari
    {
        public Pompa()
        {
            this.acquisto = 3000;
            this.installazione = 250;
            this.rendimento = 3.6;
            this.costoMateria = 0.28;
            this.tipoConsumo = "luce";
        }

        public override void Utilizzo(double consumo)
        {
            this.utilizzo = consumo * (this.pt / this.rendimento);
        }
    }
}