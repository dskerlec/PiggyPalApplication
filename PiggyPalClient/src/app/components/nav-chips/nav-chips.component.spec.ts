import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavChipsComponent } from './nav-chips.component';

describe('NavChipsComponent', () => {
  let component: NavChipsComponent;
  let fixture: ComponentFixture<NavChipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavChipsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavChipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
