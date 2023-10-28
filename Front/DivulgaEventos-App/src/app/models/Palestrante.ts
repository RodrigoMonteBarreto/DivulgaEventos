import { Evento } from './Evento';
import { RedeSocial } from './RedeSocial';
import { UserUpdate } from '@app/models/identity/UserUpdate';

export interface Palestrante {
  id: number;
  miniCurriculo: string;
  user: UserUpdate;
  imagemURL: string;
  nome: string;
  telefone: string;
  email: string;
  redesSociais: RedeSocial[];
  palestrantesEventos: Evento[];
}
