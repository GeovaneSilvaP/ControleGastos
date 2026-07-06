import axios from "axios";

/**
 * Instância do Axios configurada com a URL base da API.
 * Utilizada por todos os serviços de requisição do frontend.
 */
export const api = axios.create({
  baseURL: "http://localhost:5000/api",
});