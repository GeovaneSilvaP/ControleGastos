import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { criarTransacao } from "../../services/transacaoService";
import { listarPessoas } from "../../services/pessoaService";
import { Pessoa } from "../../interfaces/Pessoa";
import "./NovaTransacao.css";

const schema = z.object({
  descricao: z.string().min(3),
  valor: z.number().positive(),
  tipo: z.number(),
  pessoaId: z.number(),
});

type FormData = z.infer<typeof schema>;

export default function NovaTransacao() {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  useEffect(() => {
    async function carregar() {
      setPessoas(await listarPessoas());
    }
    carregar();
  }, []);

  async function salvar(data: FormData) {
    await criarTransacao(data);
    alert("Transação cadastrada.");
    reset();
  }

  return (
    <form className="form-container" onSubmit={handleSubmit(salvar)}>
      <h2>Nova Transação</h2>

      <div className="form-group">
        <input placeholder="Descrição" {...register("descricao")} />
        {errors.descricao && (
          <p className="error">{errors.descricao.message}</p>
        )}
      </div>

      <div className="form-group">
        <input
          type="number"
          step="0.01"
          placeholder="Valor"
          {...register("valor", { valueAsNumber: true })}
        />
        {errors.valor && <p className="error">{errors.valor.message}</p>}
      </div>

      <div className="form-group">
        <select {...register("tipo", { valueAsNumber: true })}>
          <option value={1}>Despesa</option>
          <option value={2}>Receita</option>
        </select>
      </div>

      <div className="form-group">
        <select {...register("pessoaId", { valueAsNumber: true })}>
          {pessoas.map((p) => (
            <option key={p.id} value={p.id}>
              {p.nome}
            </option>
          ))}
        </select>
      </div>

      <button type="submit">Salvar</button>
    </form>
  );
}
