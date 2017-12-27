const phantom = require('phantom');

(async function() {
  //const url='https://stackoverflow.com/'
  const instance = await phantom.create();
  var listURL = ['https://stackoverflow.com/','http://phantomjs.org/screen-capture.html']
  listURL.forEach(async function(url){
  const page = await instance.createPage();
  await page.on('onResourceRequested', function(requestData) {
    //console.info('Requesting', requestData.url);
  });

  const status = await page.open(url);
  const content = await page.property('content');
  var title = await page.evaluate(function(){
      return document.querySelector(".summary").innerText
    });
  console.log(title);
  page.render(url.replace("//","").replace(":","").replace("/","")+".jpg")
})
  //await instance.exit();
})();
