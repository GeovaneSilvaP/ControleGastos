import { Outlet } from "react-router-dom";
import Header from "../Header/Header";
import Sidebar from "../Sidebar/Sidebar";

import "./Layout.css";

/**
 * Estrutura base do layout da aplicação.
 * Renderiza a barra lateral e o cabeçalho fixos,
 * exibindo o conteúdo da rota atual através do Outlet.
 */
export const Layout = () => {
  return (
    <div className="layout">
      <Sidebar />

      <div className="content">
        <Header />

        <main>
          <Outlet />
        </main>
      </div>
    </div>
  );
};

export default Layout;
