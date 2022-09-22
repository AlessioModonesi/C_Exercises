namespace Bolletta
{
    class Stufa : Macchinari
    {
        public Stufa()
        {
            this.acquisto = 350;
            this.installazione = 250;
            this.rendimento = 1;
            this.costoMateria = 0.28;
            this.tipoConsumo = "luce";
        }

        public override void Utilizzo(double consumo)
        {
            this.utilizzo = consumo * (this.pt / this.rendimento);
        }
    }
}