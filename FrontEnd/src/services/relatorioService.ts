import { api } from "./api";
import { Relatorio } from "../interfaces/Relatorio";

/**
 * Busca o relatório financeiro geral, com totais
 * de receitas, despesas e saldo por pessoa.
 */
export async function obterRelatorio() {
  const response = await api.get<Relatorio>("/relatorio");

  return response.data;
}
