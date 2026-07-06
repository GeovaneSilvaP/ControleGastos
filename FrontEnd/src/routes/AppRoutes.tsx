import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "../components/Layout/Layout";
import Dashboard from "../pages/Dashboard/Dashboard";
import Pessoas from "../pages/Pessoas/Pessoas";
import NovaPessoa from "../pages/NovaPessoa/NovaPessoa";
import Transacoes from "../pages/Transacoes/Transacoes";
import NovaTransacao from "../pages/NovaTransacao/NovaTransacao";
import Relatorio from "../pages/Relatorio/Relatorio";

/**
 * Define as rotas da aplicação e associa cada caminho
 * ao seu respectivo componente de página.
 */
export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="/pessoas" element={<Pessoas />} />
          <Route path="/nova-pessoa" element={<NovaPessoa />} />
          <Route path="/transacoes" element={<Transacoes />} />
          <Route path="/nova-transacao" element={<NovaTransacao />} />
          <Route path="/relatorio" element={<Relatorio />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}