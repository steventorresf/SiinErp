import { TestBed } from '@angular/core/testing';

import { ValueListService } from './value-list.service';

describe('ValueListService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ValueListService = TestBed.get(ValueListService);
    expect(service).toBeTruthy();
  });
});