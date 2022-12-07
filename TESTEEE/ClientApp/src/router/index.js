import { createWebHistory, createRouter } from "vue-router";
import Professores from "@/components/Professores.vue";
import AlunoDetalhe from "@/components/AlunoDetalhe.vue";
import AlunosVue from "../components/Alunos.vue";
import AlunosP from "../components/AlunosP.vue";
import CadastrarAluno from "../components/CadastrarAluno.vue";

const routes = [
    {
        path: "/Alunos",
        name: "Alunos",
        component: AlunosVue,
    },
    {
        path: "/Professores",
        name: "Professores",
        component: Professores,
    },
    {
        path: "/alunoDetalhe/:id",
        name: "AlunoDetalhe",
        component: AlunoDetalhe,
    },
    {
        path: '/alunos/:prof_id',
        name: 'Alunoss',
        component: AlunosP
    },
    {
        path: "/Cadastrar",
        name: "Cadastrar",
        component: CadastrarAluno,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;