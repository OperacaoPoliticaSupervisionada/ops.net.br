namespace AuditoriaParlamentar.Classes
{
    public class FormatarDados
    {
        public Fornecedor MontarObjFornecedor(string cnpj, string resp)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.Cnpj = cnpj;

            fornecedor.RazaoSocial = recuperaColunaValor(resp, Coluna.RazaoSocial);
            fornecedor.NomeFantasia = recuperaColunaValor(resp, Coluna.NomeFantasia);
            fornecedor.Logradouro = recuperaColunaValor(resp, Coluna.EnderecoLogradouro);
            fornecedor.Numero = recuperaColunaValor(resp, Coluna.EnderecoNumero);
            fornecedor.Complemento = recuperaColunaValor(resp, Coluna.EnderecoComplemento);
            fornecedor.Bairro = recuperaColunaValor(resp, Coluna.EnderecoBairro);
            fornecedor.Cep = recuperaColunaValor(resp, Coluna.EnderecoCEP);
            fornecedor.AtividadePrincipal = recuperaColunaValor(resp, Coluna.AtividadeEconomicaPrimaria);
            fornecedor.Cidade = recuperaColunaValor(resp, Coluna.EnderecoCidade);
            fornecedor.Uf = recuperaColunaValor(resp, Coluna.EnderecoEstado);
            fornecedor.Situacao = recuperaColunaValor(resp, Coluna.SituacaoCadastral);
            fornecedor.DataSituacao = recuperaColunaValor(resp, Coluna.DataSituacaoCadastral);
            fornecedor.MotivoSituacao = recuperaColunaValor(resp, Coluna.MotivoSituacaoCadastral);
            //fornecedor.=recuperaColunaValor(resp, Coluna.NumeroInscricao);
            fornecedor.NaturezaJuridica = recuperaColunaValor(resp, Coluna.CodigoeDescricaoNaturezaJuridica);
            fornecedor.Email = recuperaColunaValor(resp, Coluna.EnderecoEletronico);
            fornecedor.Telefone = recuperaColunaValor(resp, Coluna.Telefone);
            fornecedor.EnteFederativoResponsavel = recuperaColunaValor(resp, Coluna.EnteFederativoResponsavel);
            fornecedor.DataAbertura = recuperaColunaValor(resp, Coluna.DataAbertura);
            fornecedor.SituacaoEspecial = recuperaColunaValor(resp, Coluna.SituacaoEspecial);
            fornecedor.DataSituacaoEspecial = recuperaColunaValor(resp, Coluna.DatadaSituacaoEspecial);
            fornecedor.AtividadeSecundaria01 = recuperaColunaValor(resp, Coluna.CodigoDescricaoAtividadesEconomicasSecundarias);

            return fornecedor;
        }

        private string recuperaColunaValor(string pattern, Coluna col)
        {
            var s = pattern.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            switch (col)
            {
                case Coluna.RazaoSocial:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NOME EMPRESARIAL -->", "<!-- Fim Linha NOME EMPRESARIAL -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.NomeFantasia:
                    {
                        s = stringEntreString(s, "<!-- Início Linha ESTABELECIMENTO -->", "<!-- Fim Linha ESTABELECIMENTO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.NaturezaJuridica:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NATUREZA JURÍDICA -->", "<!-- Fim Linha NATUREZA JURÍDICA -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.AtividadeEconomicaPrimaria:
                    {
                        s = stringEntreString(s, "<!-- Início Linha ATIVIDADE ECONOMICA -->", "<!-- Fim Linha ATIVIDADE ECONOMICA -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.AtividadeEconomicaSecundaria:
                    {
                        s = stringEntreString(s, "<!-- Início Linha ATIVIDADE ECONOMICA SECUNDARIA-->", "<!-- Fim Linha ATIVIDADE ECONOMICA SECUNDARIA -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.NumeroDaInscricao:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.MatrizFilial:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoLogradouro:
                    {
                        s = stringEntreString(s, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoNumero:
                    {
                        s = stringEntreString(s, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoComplemento:
                    {
                        s = stringEntreString(s, "<!-- Início Linha LOGRADOURO -->", "<!-- Fim Linha LOGRADOURO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoCEP:
                    {
                        s = stringEntreString(s, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoBairro:
                    {
                        s = stringEntreString(s, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoCidade:
                    {
                        s = stringEntreString(s, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoEstado:
                    {
                        s = stringEntreString(s, "<!-- Início Linha CEP -->", "<!-- Fim Linha CEP -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.SituacaoCadastral:
                    {
                        s = stringEntreString(s, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.DataSituacaoCadastral:
                    {
                        s = stringEntreString(s, "<!-- Início Linha SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha SITUACAO CADASTRAL -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.MotivoSituacaoCadastral:
                    {
                        s = stringEntreString(s, "<!-- Início Linha MOTIVO DE SITUAÇÃO CADASTRAL -->", "<!-- Fim Linha MOTIVO DE SITUAÇÃO CADASTRAL -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }


                //case Coluna.NumeroInscricao:
                //    {
                //        s = stringEntreString(s, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                //        s = stringEntreString(s, "<tr>", "</tr>");
                //        s = stringEntreString(s, "<b>", "</b>");
                //        return s.Trim();
                //    }

                case Coluna.CodigoeDescricaoNaturezaJuridica:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NATUREZA JURÍDICA -->", "<!-- Fim Linha NATUREZA JURÍDICA -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.EnderecoEletronico:
                    {
                        s = stringEntreString(s, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.Telefone:
                    {
                        s = stringEntreString(s, "<!-- Início de Linha de Contato -->", "<!-- Fim de Linha de Contato -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "<b>");
                        s = stringEntreString(s, "", "</font>");
                        return s.Trim();
                    }
                case Coluna.EnteFederativoResponsavel:
                    {
                        s = stringEntreString(s, "<!-- Início de Linha de Ente Federativo -->", "<!-- Fim de Linha de Ente Federativo -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.DataAbertura:
                    {
                        s = stringEntreString(s, "<!-- Início Linha NÚMERO DE INSCRIÇÃO -->", "<!-- Fim Linha NÚMERO DE INSCRIÇÃO -->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.SituacaoEspecial:
                    {
                        s = stringEntreString(s, "<!-- Início Linha SITUAÇÃO ESPECIAL -->", "<!-- Fim Linha SITUACAO ESPECIAL-->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.DatadaSituacaoEspecial:
                    {
                        s = stringEntreString(s, "<!-- Início Linha SITUAÇÃO ESPECIAL -->", "<!-- Fim Linha SITUACAO ESPECIAL-->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }
                case Coluna.CodigoDescricaoAtividadesEconomicasSecundarias:
                    {
                        s = stringEntreString(s, "<!-- Início Linha SITUAÇÃO ESPECIAL -->", "<!-- Fim Linha SITUACAO ESPECIAL-->");
                        s = stringEntreString(s, "<tr>", "</tr>");
                        s = stringSaltaString(s, "</b>");
                        s = stringEntreString(s, "<b>", "</b>");
                        return s.Trim();
                    }

                default:
                    {
                        return s;
                    }
            }
        }

        private string stringEntreString(string str, string strInicio, string strFinal)
        {
            var ini = str.IndexOf(strInicio);
            var fim = str.IndexOf(strFinal);

            if (ini > 0)
                ini = ini + strInicio.Length;

            if (fim > 0)
                fim = fim + strFinal.Length;

            var diff = ((fim - ini) - strFinal.Length);
            if ((fim > ini) && (diff > 0))
                return str.Substring(ini, diff);
            else
                return string.Empty;
        }

        private string stringSaltaString(string str, string strInicio)
        {
            var ini = str.IndexOf(strInicio);

            if (ini > 0)
            {
                ini = ini + strInicio.Length;
                return str.Substring(ini);
            }
            else
                return str;
        }

        private string stringPrimeiraLetraMaiuscula(string str)
        {
            return
                str.Length > 0 ?
                    str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower() :
                    string.Empty;

        }
    }
}