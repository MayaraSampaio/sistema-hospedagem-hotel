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
            
            bool verificaCapacidade = Suite.Capacidade >=  hospedes.Count;
            if(verificaCapacidade) 
            {
                Hospedes = hospedes;
            }
            else
            {
                
                throw new ArgumentException($"Não há capacidade para {hospedes.Count} hóspedes nesta suíte. A capacidade para a Suite é de {Suite.Capacidade} hospede(s)");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            
            decimal valor = DiasReservados * Suite.ValorDiaria;

            
            if (DiasReservados >= 10)
            {
                decimal desconto = valor * 0.10M;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}