import { RelatorioPessoa } from "./RelatorioPessoa";

export interface Relatorio {
  pessoas: RelatorioPessoa[];
  totalReceitas: number;
  totalDespesas: number;
  saldoGeral: number;
}
