//Form -- widget
// TextFormField (
// maxLenght:
// initialeValue: ''
//  decoration: InputDecoration(
// label: Text())
// validator: (value) { 
//      if(value == null || value.isEmpty)
//return sta hocemo da ispise} 
// )
// // body: ListView.builder(
  //   itemCount: ....,
  //   itemBuilder: (ctx,index) => ListTitle(
  //     title: Text(),
  //        leading:
  //      trailing:  
  // )
  // DropdownButtonFormField (
  // items: [
  //  for (final x in y)
  //  DropdownMenuItem(
  //   value: x.value --- x.key
  //    child: Row(
  //      
  // )
  // onChanged: (value) {}
  // )
  // ]
  // )
  // ako imamo problema sa prikazom dodati Expanded widget


//  ListView.builder(
//               padding: EdgeInsets.all(40),
//               itemCount: data.length,
//               itemBuilder: (context, index) => Row(
//                   mainAxisAlignment: MainAxisAlignment.spaceBetween,
//                   children: [
//                     Text(data[index].vrstaKarte ?? " ",
//                         style: TextStyle(color: Colors.orange, fontSize: 20)),
//                     Text(data[index].tipKarte ?? " ",
//                         style: TextStyle(color: Colors.orange, fontSize: 20)),
//                     Text(data[index].polaziste ?? " ",
//                         style: TextStyle(color: Colors.orange, fontSize: 20)),
//                     Text(data[index].odrediste ?? " ",
//                         style: TextStyle(color: Colors.orange, fontSize: 20)),
//                     Text(data[index].cijenaPrikaz ?? " ",
//                         style: TextStyle(color: Colors.orange, fontSize: 20)),
//                     SizedBox(
//                       height: 10,
//                     ),
//                   ]),
//             ),