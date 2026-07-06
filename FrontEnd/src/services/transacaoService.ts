import { api } from "./api";

import { CriarTransacao } from "../interfaces/CriarTransacao";
import { Transacao } from "../interfaces/Transacao";

/**
 * Busca todas as transações cadastradas.
 */
export async function listarTransacoes() {
  const response = await api.get<Transacao[]>("/transacoes");

  return response.data;
}

/**
 * Cria uma nova transação.
 * @param data Dados da transação a ser criada.
 */
export async function criarTransacao(data: CriarTransacao) {
  const response = await api.post<Transacao>("/transacoes", data);

  return response.data;
}
