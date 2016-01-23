﻿using System;
using System.Text.RegularExpressions;

namespace AuditoriaParlamentar.Classes
{
    public class FormatarDados
    {
        public Fornecedor MontarObjFornecedor(string cnpj, string responseFromServer)
        {
            Fornecedor fornecedor = new Fornecedor();

            if (responseFromServer.IndexOf("NOME EMPRESARIAL") > 0)
            {
                string textoHTML = Regex.Replace(responseFromServer, @"<[^>]*>", string.Empty);
                textoHTML = textoHTML.Substring(textoHTML.IndexOf("NÚMERO DE INSCRIÇÃO"));
                textoHTML = textoHTML.Substring(0, textoHTML.IndexOf("Aprovado pela Instrução Normativa")).Replace("NÚMERO DE INSCRIÇÃO", "").Trim();
                textoHTML = Regex.Replace(textoHTML, "&nbsp;", string.Empty).Trim();
                fornecedor.Cnpj = cnpj; //textoHTML.Substring(0, textoHTML.IndexOf("\r\n"));

                textoHTML = textoHTML.Replace(fornecedor.Cnpj, "");
                fornecedor.Matriz = (textoHTML.Substring(0, textoHTML.IndexOf("COMPROVANTE")).Trim().Equals("MATRIZ")) ? 1 : 0;

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("DATA DE ABERTURA")).Replace("DATA DE ABERTURA", "").Trim();
                fornecedor.DataAbertura = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("NOME EMPRESARIAL")).Replace("NOME EMPRESARIAL", "").Trim();
                fornecedor.RazaoSocial = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("(NOME DE FANTASIA)")).Replace("(NOME DE FANTASIA)", "").Trim();
                fornecedor.NomeFantasia = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.NomeFantasia.Substring(0, 1) == "*")
                    fornecedor.NomeFantasia = fornecedor.RazaoSocial;

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL")).Replace("CÓDIGO E DESCRIÇÃO DA ATIVIDADE ECONÔMICA PRINCIPAL", "").Trim();
                fornecedor.AtividadePrincipal = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.AtividadePrincipal.Substring(0, 1) == "*")
                    fornecedor.AtividadePrincipal = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS")).Replace("CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ECONÔMICAS SECUNDÁRIAS", "").Trim();
                fornecedor.AtividadeSecundaria01 = textoHTML.Substring(0, textoHTML.IndexOf("CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA")).Trim();
                if (fornecedor.AtividadeSecundaria01.Equals("Não informada"))
                    fornecedor.AtividadeSecundaria01 = "";
                else
                {
                    fornecedor.AtividadeSecundaria01 = fornecedor.AtividadeSecundaria01.Replace("  ", "").Replace("\t", "").Replace("\r\n\r\n\r\n\r\n", "");
                    var atividadeSecundaria = fornecedor.AtividadeSecundaria01.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    try
                    {
                        fornecedor.AtividadeSecundaria01 = atividadeSecundaria[0];
                        fornecedor.AtividadeSecundaria02 = atividadeSecundaria[1];
                        fornecedor.AtividadeSecundaria03 = atividadeSecundaria[2];
                        fornecedor.AtividadeSecundaria04 = atividadeSecundaria[3];
                        fornecedor.AtividadeSecundaria05 = atividadeSecundaria[4];
                        fornecedor.AtividadeSecundaria06 = atividadeSecundaria[5];
                        fornecedor.AtividadeSecundaria07 = atividadeSecundaria[6];
                        fornecedor.AtividadeSecundaria08 = atividadeSecundaria[7];
                        fornecedor.AtividadeSecundaria09 = atividadeSecundaria[8];
                        fornecedor.AtividadeSecundaria10 = atividadeSecundaria[9];
                        fornecedor.AtividadeSecundaria11 = atividadeSecundaria[10];
                        fornecedor.AtividadeSecundaria12 = atividadeSecundaria[11];
                        fornecedor.AtividadeSecundaria13 = atividadeSecundaria[12];
                        fornecedor.AtividadeSecundaria14 = atividadeSecundaria[13];
                        fornecedor.AtividadeSecundaria15 = atividadeSecundaria[14];
                        fornecedor.AtividadeSecundaria16 = atividadeSecundaria[15];
                        fornecedor.AtividadeSecundaria17 = atividadeSecundaria[16];
                        fornecedor.AtividadeSecundaria18 = atividadeSecundaria[17];
                        fornecedor.AtividadeSecundaria19 = atividadeSecundaria[18];
                        fornecedor.AtividadeSecundaria20 = atividadeSecundaria[19];
                    }
                    catch (IndexOutOfRangeException)
                    { }
                }

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA")).Replace("CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA", "").Trim();
                fornecedor.NaturezaJuridica = textoHTML.Substring(0, textoHTML.IndexOf("PORTE DA EMPRESA")).Replace("PORTE DA EMPRESA", "").Trim();
                if (fornecedor.NaturezaJuridica.Equals("LOGRADOURO"))
                    fornecedor.NaturezaJuridica = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("LOGRADOURO")).Replace("LOGRADOURO", "").Trim();
                fornecedor.Logradouro = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Logradouro.Equals("NÚMERO"))
                    fornecedor.Logradouro = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("NÚMERO")).Replace("NÚMERO", "").Trim();
                fornecedor.Numero = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Numero.Equals("COMPLEMENTO"))
                    fornecedor.Numero = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("COMPLEMENTO")).Replace("COMPLEMENTO", "").Trim();
                fornecedor.Complemento = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Complemento.Equals("CEP"))
                    fornecedor.Complemento = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("CEP")).Replace("CEP", "").Trim();
                fornecedor.Cep = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim().Replace(".", "");
                if (fornecedor.Cep.Equals("DISTRITO"))
                    fornecedor.Cep = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("DISTRITO")).Replace("DISTRITO", "").Trim();
                fornecedor.Bairro = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Bairro.Equals("MUNICÍPIO"))
                    fornecedor.Bairro = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("MUNICÍPIO")).Replace("MUNICÍPIO", "").Trim();
                fornecedor.Cidade = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Cidade.Equals("UF"))
                    fornecedor.Cidade = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("UF")).Replace("UF", "").Trim();
                fornecedor.Uf = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Uf.Equals("ENDEREÇO ELETRÔNICO"))
                    fornecedor.Uf = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("ENDEREÇO ELETRÔNICO")).Replace("ENDEREÇO ELETRÔNICO", "").Trim();
                fornecedor.Email = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Email.Equals("TELEFONE"))
                    fornecedor.Email = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("TELEFONE")).Replace("TELEFONE", "").Trim();
                fornecedor.Telefone = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Telefone.Equals("ENTE FEDERATIVO RESPONSÁVEL(EFR)"))
                    fornecedor.Telefone = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("ENTE FEDERATIVO RESPONSÁVEL (EFR)")).Replace("ENTE FEDERATIVO RESPONSÁVEL (EFR)", "").Trim();
                fornecedor.EnteFederativoResponsavel = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.EnteFederativoResponsavel.Substring(0, 1) == "*")
                    fornecedor.EnteFederativoResponsavel = "";

                textoHTML = ReplaceFirst(textoHTML.Substring(textoHTML.IndexOf("SITUAÇÃO CADASTRAL")), "SITUAÇÃO CADASTRAL", "").Trim();
                fornecedor.Situacao = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.Situacao.Equals("DATA DA SITUAÇÃO CADASTRAL"))
                    fornecedor.Situacao = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("DATA DA SITUAÇÃO CADASTRAL")).Replace("DATA DA SITUAÇÃO CADASTRAL", "").Trim();
                fornecedor.DataSituacao = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.DataSituacao.Equals("MOTIVO DE SITUAÇÃO CADASTRAL"))
                    fornecedor.DataSituacao = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("MOTIVO DE SITUAÇÃO CADASTRAL")).Replace("MOTIVO DE SITUAÇÃO CADASTRAL", "").Trim();
                fornecedor.MotivoSituacao = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.MotivoSituacao.Equals("SITUAÇÃO ESPECIAL"))
                    fornecedor.MotivoSituacao = "";

                textoHTML = ReplaceFirst(textoHTML.Substring(textoHTML.IndexOf("SITUAÇÃO ESPECIAL")), "SITUAÇÃO ESPECIAL", "").Trim();
                fornecedor.SituacaoEspecial = textoHTML.Substring(0, textoHTML.IndexOf("\r\n")).Trim();
                if (fornecedor.SituacaoEspecial.Substring(0, 1) == "*")
                    fornecedor.SituacaoEspecial = "";

                textoHTML = textoHTML.Substring(textoHTML.IndexOf("DATA DA SITUAÇÃO ESPECIAL")).Replace("DATA DA SITUAÇÃO ESPECIAL", "").Trim();
                fornecedor.DataSituacaoEspecial = textoHTML;
                if (fornecedor.DataSituacaoEspecial.Substring(0, 1) == "*")
                    fornecedor.DataSituacaoEspecial = "";

                return fornecedor;

            }
            else if (responseFromServer.IndexOf("Verifique se o mesmo foi digitado corretamente") > 0)
            {
                throw new System.Exception("CNPJ não localizado junto a receita federal.");
            }
            else if (responseFromServer.IndexOf("Digite os caracteres acima:") > 0)
            {
                throw new System.Exception("Capcha incorreto.");
            }
            return null;
        }

        string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}