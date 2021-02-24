import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Pais } from 'src/app/interfaces/general/pais';
import { NotificationService } from 'src/app/services/common/notification.service';
import { PaisService } from 'src/app/services/general/pais.service';

@Component({
  selector: 'app-pais',
  templateUrl: './pais.component.html',
  styleUrls: ['./pais.component.scss']
})
export class PaisComponent implements OnInit {
  listOfData: Pais[] = [];
  isVisible = false;
  isCreateMode = true;
  siinerpForm!: FormGroup;

  constructor(private service: PaisService, private fb: FormBuilder, private alert: NotificationService) { }

  ngOnInit(): void {
    this.resetAll();
  }

  resetAll(): void {
    this.readAll();
    this.isVisible = false;
    this.isCreateMode = true;
    this.siinerpForm = this.fb.group({
      idPais: [0, [Validators.required]],
      nombrePais: [null, [Validators.required, Validators.maxLength(50)]],
      codigoDane: [null, [Validators.required, Validators.maxLength(10)]],
      fechaCreacion: [new Date(), [Validators.required]],
      creadoPor: ['ADMIN', [Validators.required]],
      estadoFila: ['A', [Validators.required]]
    });
  }

  /**
   * Metodo para obtener todos los objetos
   */
  readAll(): void {
    this.service.readAll()
      .subscribe((res: any) => {
        this.listOfData = res;
      }, err => {
        console.error(err);
      });
  }

  /**
   * Metodo para crear un nuevo objeto
   * @param obj Objeto que se va a crear
   */
  create(obj: Pais): void {
    this.service.create(obj)
      .subscribe((res: any) => {
        this.alert.successCreation();
        this.resetAll();
      }, err => {
        this.alert.error('Error', err);
      });
  }

  /**
   * Metodo para actualizar un objeto
   * @param id Llave del objeto
   * @param obj Objeto que se va a modificar
   */
  update(id: number, obj: Pais): void {
    this.service.update(id, obj)
      .subscribe((res: any) => {
        this.alert.successUpdate();
        this.resetAll();
      }, err => {
        this.alert.error('Error', err);
      });
  }

  /**
   * Metodo que permite mostrar el titulo del modal
   * dependiendo de ciertas condiciones.
   */
  getModalTitle(): string {
    return this.isCreateMode ? "Crear Pais" : "Editar Pais";
  }

  createModal() {
    this.resetAll();
    this.isCreateMode = true;
    this.isVisible = true;
  }

  updateModal(entity: Pais) {
    this.isCreateMode = false;
    this.isVisible = true;
    this.siinerpForm.patchValue({
      idPais: entity.idPais,
      nombrePais: entity.nombrePais,
      codigoDane: entity.codigoDane,
      fechaCreacion: entity.fechaCreacion,
      creadoPor: entity.creadoPor,
      estadoFila: entity.estadoFila
    });
  }

  hideModal(): void {
    this.isVisible = false;
  }

  submitForm(): void {
    for (const i in this.siinerpForm.controls) {
      this.siinerpForm.controls[i].markAsDirty();
      this.siinerpForm.controls[i].updateValueAndValidity();
    }
    console.log(this.siinerpForm.valid);
    if (this.siinerpForm.valid) {
      const obj: Pais = {
        idPais: this.isCreateMode ? 0 : this.siinerpForm.value.idPais,
        nombrePais: this.siinerpForm.value.nombrePais,
        codigoDane: this.siinerpForm.value.codigoDane,
        fechaCreacion: this.isCreateMode ? new Date() : this.siinerpForm.value.fechaCreacion,
        creadoPor: this.isCreateMode ? 'SYSTEM' : this.siinerpForm.value.creadoPor,
        fechaModificado: new Date(),
        modificadoPor: 'SYSTEM',
        estadoFila: this.isCreateMode ? 'A' : this.siinerpForm.value.estadoFila
      };
      console.log(obj);
      if (this.isCreateMode) {
        this.create(obj);
      } else {
        this.update(obj.idPais, obj);
      }
    }
  }
}