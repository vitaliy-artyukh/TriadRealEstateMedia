// $(document).ready(function () {
//     loadContacts();
// });
//
// function loadContacts() {
//     $.ajax({
//         url: '@Url.Action("GetContacts", "Contacts")',
//         type: 'GET',
//         success: function (data) {
//             const tableBody = $('#contactsTableBody');
//             tableBody.empty(); // Clear any existing rows
//             if (data.contacts && data.contacts.length) {
//                 $.each(data, function (index, contact) {
//                     const row = `
//                         <tr>
//                             <td>${contact.firstName}</td>
//                             <td>${contact.lastName}</td>
//                             <td>${contact.phoneNumber}</td>
//                             <td>${contact.email}</td>
//                             <td>${contact.description}</td>
//                             <td>
//                                 <a href="/Contacts/Edit/${contact.id}" class="btn btn-secondary">Edit</a>
//                                 <a href="/Contacts/Delete/${contact.id}" class="btn btn-danger">Delete</a>
//                             </td>
//                         </tr>`;
//                     tableBody.append(row);
//                 });
//             } else {
//                 const row = '<tr> No data to display.</tr>';
//             }
//         },
//         error: function (error) {
//             console.error('Error fetching contacts:', error);
//         }
//     });
// }