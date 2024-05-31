import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickAddFormComponent } from './quick-add-form.component';

describe('QuickAddFormComponent', () => {
  let component: QuickAddFormComponent;
  let fixture: ComponentFixture<QuickAddFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuickAddFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(QuickAddFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
