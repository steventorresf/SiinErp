import { TestBed } from '@angular/core/testing';

import { ConceptoService } from './concepto.service';

describe('ConceptoService', () => {
  let service: ConceptoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConceptoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
