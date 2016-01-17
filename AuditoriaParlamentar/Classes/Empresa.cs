namespace AuditoriaParlamentar.Classes
{
    public class Empresa
    {

        public Empresa(
            string cnpj, string razaosocial, string nomefantasia, string endereco,
            string bairro, string cep, string cnae, string cidade, string estado, 
            string SituacaoCadastral, string DataSituacaoCadastral, string MotivoSituacaoCadastral, string NumeroInscricao,
            string CodigoeDescricaoNaturezaJuridica, string EnderecoEletronico, string Telefone, string EnteFederativoResponsavel, string DataAbertura,
            string SituacaoEspecial, string DatadaSituacaoEspecial, string CodigoDescricaoAtividadesEconomicasSecundarias)
        {
            this.CNPJ = cnpj;
            this.Razaosocial = razaosocial;
            this.NomeFantasia = nomefantasia;
            this.Endereco = endereco;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Cnae = cnae;
            this.Cidade = cidade;
            this.Estado = estado;
            this.SituacaoCadastral = SituacaoCadastral;
            this.DataSituacaoCadastral = DataSituacaoCadastral;
            this.MotivoSituacaoCadastral = MotivoSituacaoCadastral;
            this.NumeroInscricao = NumeroInscricao;
            this.CodigoeDescricaoNaturezaJuridica = CodigoeDescricaoNaturezaJuridica;
            this.EnderecoEletronico = EnderecoEletronico;
            this.Telefone = Telefone;
            this.EnteFederativoResponsavel = EnteFederativoResponsavel;
            this.DataAbertura = DataAbertura;
            this.SituacaoEspecial = SituacaoEspecial;
            this.DatadaSituacaoEspecial = DatadaSituacaoEspecial;
            this.CodigoDescricaoAtividadesEconomicasSecundarias = CodigoDescricaoAtividadesEconomicasSecundarias;
        }

        public string CNPJ { get; private set; }

        public string Razaosocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string Endereco { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string Cnae { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string SituacaoCadastral { get; private set; }

        public string DataSituacaoCadastral { get; private set; }

        public string MotivoSituacaoCadastral { get; private set; }

        public string NumeroInscricao { get; private set; }

        public string CodigoeDescricaoNaturezaJuridica { get; private set; }

        public string EnderecoEletronico { get; private set; }

        public string Telefone { get; private set; }

        public string EnteFederativoResponsavel { get; private set; }

        public string DataAbertura { get; private set; }

        public string SituacaoEspecial { get; private set; }

        public string DatadaSituacaoEspecial { get; private set; }

        public string CodigoDescricaoAtividadesEconomicasSecundarias { get; private set; }
    }
}