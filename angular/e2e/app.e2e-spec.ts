import { BrenomaTemplatePage } from './app.po';

describe('Brenoma App', function() {
  let page: BrenomaTemplatePage;

  beforeEach(() => {
    page = new BrenomaTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
