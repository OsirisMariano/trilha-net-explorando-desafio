namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a suíte foi cadastrada antes de tentar adicionar hóspedes
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível cadastrar hóspedes sem antes cadastrar uma suíte.");
            }

            // valida capacidade
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança exceção quando houver mais hóspedes do que a capacidade permite
                throw new ArgumentException("Capacidade insuficiente para o número de hóspedes informado.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna quantidade de hóspedes cadastrados na reserva
            return Hospedes == null ? 0 : Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Suíte não cadastrada na reserva.");
            }

            // valor inicial sem descontos
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // aplica desconto de 10% se a reserva for de 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.10m;
            }

            return valor;
        }
    }
}