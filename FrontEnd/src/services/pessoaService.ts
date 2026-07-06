import { api } from "./api";
import { Pessoa } from "../interfaces/Pessoa";
import { CriarPessoa } from "../interfaces/CriarPessoa";

/**
 * Busca todas as pessoas cadastradas.
 */
export async function listarPessoas() {
  const response = await api.get<Pessoa[]>("/pessoas");

  return response.data;
}

/**
 * Cria uma nova pessoa.
 * @param data Dados da pessoa a ser criada.
 */
export async function criarPessoa(data: CriarPessoa) {
  const response = await api.post<Pessoa>("/pessoas", data);

  return response.data;
}

/**
 * Exclui uma pessoa pelo ID.
 * @param id Identificador da pessoa.
 */
export async function excluirPessoa(id: number) {
  await api.delete(`/pessoas/${id}`);
}
