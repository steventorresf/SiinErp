import { Auditoria } from "../common/auditoria";

export interface Pais extends Auditoria {
  idPais: number;
  nombrePais: string;
  codigoDane: string;
}
