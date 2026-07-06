import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { criarPessoa } from "../../services/pessoaService";
import "./NovaPessoa.css";
import NovaTransacao from "../NovaTransacao/NovaTransacao";

const schema = z.object({
  nome: z.string().min(3, "Nome muito curto"),
  idade: z.number().min(0).max(120),
});

type FormData = z.infer<typeof schema>;

const NovaPessoa = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  async function salvar(data: FormData) {
    await criarPessoa(data);
    alert("Pessoa cadastrada!");
    reset();
  }

  return (
    <form className="form-container" onSubmit={handleSubmit(salvar)}>
      <h2>Nova Pessoa</h2>

      <div className="form-group">
        <input placeholder="Nome" {...register("nome")} />
        {errors.nome && <p className="error">{errors.nome.message}</p>}
      </div>

      <div className="form-group">
        <input
          type="number"
          placeholder="Idade"
          {...register("idade", { valueAsNumber: true })}
        />
        {errors.idade && <p className="error">{errors.idade.message}</p>}
      </div>

      <button type="submit">Salvar</button>
    </form>
  );
};

export default NovaPessoa;
