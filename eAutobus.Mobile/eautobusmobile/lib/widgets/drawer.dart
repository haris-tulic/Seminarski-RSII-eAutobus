// import 'package:flutter/cupertino.dart';
// import 'package:flutter/material.dart';

// class SideDrawer extends StatelessWidget{
//   @override
//   Widget build(BuildContext context) {
//        	return ListView(
//           children: <Widget>[
//             UserAccountsDrawerHeader(
//               accountName: Text('${widget.username}!'),
//               accountEmail: Text('johndoe@example.com'),
//               currentAccountPicture: CircleAvatar(
//                 backgroundColor: Colors.white,
//                 child: Text(
//                   'JD',
//                   style: TextStyle(fontSize: 40.0),
//                 ),
//               ),
//             ),
//             ListTile(
//               leading: Icon(Icons.home),
//               title: Text('Pocetna'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//             ListTile(
//               leading: Icon(Icons.price_change_rounded),
//               title: Text('Cjenovnik'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//             ListTile(
//               leading: Icon(Icons.calendar_month_outlined),
//               title: Text('Red voznje'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//             ListTile(
//               leading: Icon(Icons.receipt_long_outlined),
//               title: Text('Rezervacija karte'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//             ListTile(
//               leading: Icon(Icons.recommend),
//               title: Text('Recenzija'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//             Divider(),
//             ListTile(
//               leading: Icon(Icons.exit_to_app),
//               title: Text('Logout'),
//               onTap: () {
//                 Navigator.pop(context);
//               },
//             ),
//           ],
//         ),
//   }
// }